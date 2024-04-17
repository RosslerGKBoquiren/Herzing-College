<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>LOGIN</h1>
        </div>
    </header>

    <?php
    // Check if logout parameter is set and logout cookie
    if(isset($_GET['logout']) && $_GET['logout'] == 'true') {
        // Unset the cookie
        setcookie('loggedin', '', time() - 3600, '/');
        // Redirect to login page
        header('Location: login.php');
        exit();
    }

    // Check if user is already logged in
    if(isset($_COOKIE['loggedin']) && $_COOKIE['loggedin'] == 'true') {
        // Show logout link
        echo '<a href="login.php?logout=true">Logout</a>';
        exit();
    }

    // Check if form is submitted
    if($_SERVER['REQUEST_METHOD'] === 'POST' && isset($_POST['username']) && isset($_POST['password'])) {
        // Database connection
        $database_connect = mysqli_connect('localhost', 'root', '', 'store') 
            or die ("Error connecting to MySQL server.");

        // Retrieve user inputs
        $username = isset($_POST['username']) ? $_POST['username'] : '';
        $password = isset($_POST['password']) ? $_POST['password'] : '';

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
                // User exists, set loggedin cookie
                setcookie('loggedin', 'true', time() + 120, '/');
                // Redirect to login page to show logout link
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
    }
    ?>


    <!-- Login form -->
    <div id="form-div">
        <form action="login.php" method="post">
            <label for="username">Username:</label>
            <input type="text" id="username" name="username" required><br>
            <label for="password">Password:</label>
            <input type="password" id="password" name="password" required><br>
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
