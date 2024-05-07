<?php
ob_start();
// Start session
session_start();

// Function to log errors
function logError($errorMessage) {
    error_log($errorMessage . PHP_EOL, 3, 'logerrors.log'); 
}

// Check if logout parameter is set and logout session
if(isset($_GET['logout']) && $_GET['logout'] == 'true') {
    // Clear session variables
    session_unset();
    // Destroy the session
    session_destroy();
    // Redirect to login page
    header('Location: login.php');
    exit();
}

// Database connection
$database_connect = mysqli_connect('localhost', 'root', '', 'store') 
    or die ("Error connecting to MySQL server.");

// Check if form is submitted
if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['message'])) {
    try {
        // Retrieve the logged-in username from the session
        $username = $_SESSION['username'];
        // Retrieve the message from the form and escape special characters
        $message = isset($_POST['message']) ? mysqli_real_escape_string($database_connect, $_POST['message']) : '';

        // Insert the message into the database using prepared statement
        $insert_query = "INSERT INTO messages (username, message) VALUES (?, ?)";
        $statement = mysqli_prepare($database_connect, $insert_query);
        mysqli_stmt_bind_param($statement, "ss", $username, $message);
        mysqli_stmt_execute($statement);
        
        // Check if the message was inserted successfully
        if(mysqli_stmt_affected_rows($statement) > 0) {
            // Redirect back to the main page
            header('Location: dashboard.php');
            exit();
        } else {
            // Show error message
            echo '<div class="error_message">Failed to insert message into database.</div>';
        }
        
        // Close the prepared statement
        mysqli_stmt_close($statement);
    } catch (Exception $e) {
        // Log exception
        logError('Exception caught: ' . $e->getMessage());
        echo '<div class="error_message">An error occurred. Please try again later.</div>';
    }
}
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dashboard</title>
    <link rel="stylesheet" type="text/css" href="login_style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>MINI - CHAT</h1>
        </div>
    </header>

    <?php
    if ($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['message'])) {
        // Retrieve the logged-in username from the session
        $username = $_SESSION['username'];
        // Retrieve the message from the form
        $message = $_POST['message'];

        // Insert the message into the database
        $insert_query = "INSERT INTO messages (username, message) VALUES ('$username', '$message')";
        
        // Attempt to execute the query
        if(mysqli_query($database_connect, $insert_query)) {
            // Message inserted successfully
            header('Location: dashboard.php');
            exit();
        } else {
            // Error inserting message
            echo "Error: " . mysqli_error($database_connect);
        }
    }
    ?>

    <?php
    // Fetch the latest messages from the database along with user photos
    $query_messages = "SELECT messages.*, users.photo FROM messages LEFT JOIN users ON messages.username = users.username ORDER BY messages.id DESC LIMIT 5";
    // Fetching maximum of 5 messages from the database
    $result_messages = mysqli_query($database_connect, $query_messages);

    ?>

    <!-- Messages div -->
    <div class="random-messages">
        <?php
        // Loop through each fetched message
        while ($row_message = mysqli_fetch_assoc($result_messages)) {
            // Display the message without backslashes
            echo '<div class="user-message">';
            echo '<img src="' . $row_message['photo'] . '" alt="User Photo">';
            echo '<p><strong>' . $row_message['username'] . ':</strong> ' . stripslashes($row_message['message']) . '</p>';
            echo '</div>'; // Close user-message div
        }

        ?>
    </div>

    <div class="content-wrapper">
    <?php
    // Retrieve username and photo path based on logged-in user
    $username = $_SESSION['username'];
    $query = "SELECT username, photo, first_name FROM users WHERE username = '$username'";
    $result = mysqli_query($database_connect, $query);

    // Check if user exists
    if (!$result) {
        // Display error message
        echo '<div class="user-profile">';
        echo '<p>Error: Unable to fetch user information.</p>';
        echo '</div>';
    } else {
        if (mysqli_num_rows($result) > 0) {
            $row = mysqli_fetch_assoc($result);
            $photo_path = $row['photo'];
            $username = $row['username'];
            $first_name = $row['first_name'];

            // Display user profile
            echo '<div class="user-profile">';
            echo "<img src='$photo_path' alt='User Photo' class='profile-photo'>";
            echo "<div class='profile-details'>";
            echo "<p class='welcome-message'>Welcome back, $first_name!</p>";
            echo '<form action="login.php" method="get">';
            echo '<button type="submit" name="logout" class="logout-button">Logout</button>';
            echo '</form>';
            echo "</div>"; 
            echo '</div>'; 

            // Message sending form
            echo '<div class="message-form">';
            echo '<form action="" method="post">'; // Change the action to an empty string to post to the same page
            echo '<textarea name="message" placeholder="Type your message here"></textarea>';
            echo '<button type="submit" class="send-button">Send Message</button>';
            echo '</form>';
            echo '</div>'; 
        } else {
            // User not found
            echo '<div class="user-profile">';
            echo '<p>Error: User not found.</p>';
            echo '</div>';
        }
    }

    // Close database connection
    mysqli_close($database_connect);
    ?>
    </div>

    <footer>
        <div id="footer-div">
            <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
        </div>
    </footer>
</body>
</html>

 
