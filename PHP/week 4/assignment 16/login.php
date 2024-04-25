<?php
// Start output buffering
ob_start();
// Start session
session_start();

// Function to log errors
function logError($errorMessage) {
    error_log($errorMessage . PHP_EOL, 3, 'logerrors.log'); // PHP_EOL cross-platform \n (newline)
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
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="login_style.css">
</head>
<body class="login-page">
    <header>
        <div class="header">
            <h1>LOGIN</h1>
        </div>
    </header>

    <?php
    // Check if form is submitted
    if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['username']) && isset($_POST['password'])) {
        try {
            // Database connection
            $database_connect = mysqli_connect('localhost', 'root', '', 'store') 
                or die ("Error connecting to MySQL server.");

            // Retrieve user inputs
            $username = isset($_POST['username']) ? htmlspecialchars($_POST['username']) : '';
            $password = isset($_POST['password']) ? htmlspecialchars($_POST['password']) : '';

            // Check if username and password are not empty
            if (!empty($username) && !empty($password)) {
                // Hash the submitted password using sha1
                $hashed_password = sha1($password);

                // Construct SQL query to check username and hashed password
                $query = "SELECT * FROM users WHERE username = '$username' AND password = '$hashed_password'";

                // Execute the query
                $result = mysqli_query($database_connect, $query);

                // Check if user exists
                if (mysqli_num_rows($result) > 0) {
                    // User exists, set session variables
                    $_SESSION['loggedin'] = true;
                    // Redirect to dashboard if user is logged in
                    header('Location: dashboard.php');
                    exit();
                } else {
                    // Show error message
                    echo '<div class="error_message">Invalid username or password.</div>';
                }
            } else {
                // Show error message for missing username or password
                echo '<div class="error_message">Please enter both username and password.</div>';
            }
        } catch (Exception $e) {
            // Log exception
            logError('Exception caught: ' . $e->getMessage());
            // Show generic error message
            echo '<div class="error_message">An error occurred. Please try again later.</div>';
        }
    }
    ?>

    <!-- Login form -->
    <div id="form-div">
        <form action="login.php" method="post" class="form">
            <label for="username">Username:</label>
            <input type="text" id="username" name="username" placeholder="Enter your username" required>
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" placeholder="Enter your password" required>
            <input type="submit" id="btnSubmit" value="Login">
        </form>
    </div>
    
    <footer>
        <div id="footer-div">
            <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
        </div>
    </footer>
</body>
</html>

<?php
// Flush output buffer
ob_end_flush();
?>

