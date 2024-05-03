<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Dashboard</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>Dashboard</h1>
        </div>
    </header>

    <nav>
        <div class="menu">
             <span><a href="login.php?logout=true">LOGOUT</a></span>
        </div>
    </nav>

    <div class="dashboard_content">
        <?php
        // Start session
        session_start();

        // Check if user is logged in
        if(isset($_SESSION['loggedin']) && $_SESSION['loggedin'] === true) {
            // Database connection
            $database_connect = mysqli_connect('localhost', 'root', '', 'store') 
                or die ("Error connecting to MySQL server.");

            // Retrieve username and photo path based on logged-in user
            $username = $_SESSION['username'];
            $query = "SELECT username, photo FROM users WHERE username = '$username'";
            $result = mysqli_query($database_connect, $query);

            // Check if user exists
            if (mysqli_num_rows($result) > 0) {
                $row = mysqli_fetch_assoc($result);
                $photo_path = $row['photo'];
                $username = $row['username'];

                // Display welcome message with username and photo
                echo "<p>Welcome to your dashboard, $username!</p>";
                echo "<img src='$photo_path' alt='User Photo' class='profile-photo'>";
            } else {
                // User not found
                echo '<p>Error: User not found.</p>';
            }

            // Close database connection
            mysqli_close($database_connect);
        } else {
            // User is not logged in, redirect to login page
            header('Location: login.php');
            exit();
        }
        ?>
    </div>

    <footer>
        <div id="footer-div">
            <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
        </div>
    </footer>
</body>
</html>


