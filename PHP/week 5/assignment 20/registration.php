<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>REGISTRATION FORM</title>
    <link rel="stylesheet" type="text/css" href="registration_style.css">   
</head>
<body class="registration-page">

    <header>
        <div class="header">
            <h1>REGISTRATION FORM</h1>
        </div>
    </header>

    <nav>
        <div class="menu">
             <span><a href="registration.php">REGISTRATION</a></span>
             <span><a href="table.php">LIST</a></span>
        </div>
    </nav>

    <main>
    <?php
    require_once('form_check.php');

        if(isset($_POST['btnSubmit'])) {
            // Check all fields are provided
            if(empty($_POST['username']) || empty($_POST['first_name']) || empty($_POST['last_name']) || empty($_POST['password']) || empty($_POST['confirm_password']) || empty($_POST['email']) || !isset($_POST['accept_terms'])) {
                echo '<div class="output_message error_message">You have to provide all the information.</div>';
            } else {
                // Validate email format
                $email = $_POST['email'];
                if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                    echo '<div class="output_message error_message">Invalid email address format.</div>';
                } else {
                    // Check if password matches confirm password
                    $password = $_POST['password'];
                    $confirm_password = $_POST['confirm_password'];
                    if ($password !== $confirm_password) {
                        echo '<div class="output_message error_message">Passwords do not match.</div>';
                    } else {
                        // Call the Captcha files
                        require_once 'securimage/securimage.php';
                        $securimage = new Securimage(); // Instance of the Secure Image Class
                        
                        // Validate Captcha
                        if ($securimage->check($_POST['captcha_code']) == false) {
                            echo '<div class="output_message error_message">The security code entered was incorrect. Please try again.</div>';
                        } else {
                            // Captcha validation passed, continue with other checks
                            // Sanitize inputs
                            $username = addslashes(strip_tags($_POST['username']));
                            $first_name = addslashes(strip_tags($_POST['first_name']));
                            $last_name = addslashes(strip_tags($_POST['last_name']));
                            // Note: We won't sanitize password here
                            $password = $_POST['password'];
                            $email = addslashes(strip_tags($_POST['email']));

                            // Retrieve the value of province from the form submission
                            $province = isset($_POST["province"]) ? $_POST["province"] : "";

                            // Connect to the database
                            $database_connect = mysqli_connect('localhost', 'root', '', 'store') or die ('Error connecting to MySQL server.');
                            
                            // Hash the password using sha1
                            $hashed_password = sha1($password);
                            
                            // Insert data into database
                            $query = "INSERT INTO users (username, first_name, last_name, password, email, province) 
                                VALUES ('$username', '$first_name', '$last_name', '$hashed_password', '$email', '$province')";
                            $result = mysqli_query($database_connect, $query);
                            
                            // Check if insertion was successful
                            if ($result) {
                                echo '<div class="confirm_message">Your form has been completed correctly</div>';
                            } else {
                                echo '<div class="confirm_message">An error occurred. Please try again later</div>';
                            }

                            // Close the database connection
                            mysqli_close($database_connect);
                        }
                    }
                }
            }
        }
    ?>


    <div id="form-div">
        <form class="form" method="post">
            <label for="username">Username:</label> <input type='text' id='username' name='username' placeholder='Enter your Username...' value='<?php echo isset($_POST["username"]) ? htmlspecialchars($_POST["username"]) : ""; ?>'><br>
            <label for="first_name">First Name:</label> <input type='text' id='first_name' name='first_name' placeholder='Enter your First Name...' value='<?php echo isset($_POST["first_name"]) ? htmlspecialchars($_POST["first_name"]) : ""; ?>'><br>
            <label for="last_name">Last Name:</label> <input type='text' id='last_name' name='last_name' placeholder='Enter your Last Name...' value='<?php echo isset($_POST["last_name"]) ? htmlspecialchars($_POST["last_name"]) : ""; ?>'><br>
            <label for="password">Password:</label> <input type='password' id='password' name='password' placeholder='Enter your Password...' value='<?php echo isset($_POST["password"]) ? htmlspecialchars($_POST["password"]) : ""; ?>'><br>
            <label for="confirm_password">Confirm Password:</label> <input type='password' id='confirm_password' name='confirm_password' placeholder='Confirm your Password...'><br>
            <!-- regular expression validation for Email -->
            <label for="email">Email:</label> 
            <input type='text' id='email' name='email' placeholder='Enter your Email...' value='<?php echo isset($_POST["email"]) ? htmlspecialchars($_POST["email"]) : ""; ?>' pattern="^[^0-9][A-z0-9_]+([.][A-z0-9_]+)*[@][A-z0-9_]+([.][A-z0-9_]+)*[.][A-z]{2,4}$" required><br>

            <label for="province">Province:</label>
            <select id="province" name="province">
                <option value='' <?php echo (!isset($_POST["province"]) || empty($_POST["province"])) ? "selected" : ""; ?>>Select Province</option>
                <option value='Manitoba' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Manitoba") ? "selected" : ""; ?>>Manitoba</option>
                <option value='New Brunswick' <?php echo (isset($_POST["province"]) && $_POST["province"] == "New Brunswick") ? "selected" : ""; ?>>New Brunswick</option>
                <option value='Prince Edward Island' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Prince Edward Island") ? "selected" : ""; ?>>Prince Edward Island</option>
                <option value='Quebec' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Quebec") ? "selected" : ""; ?>>Quebec</option>
                <option value='Alberta' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Alberta") ? "selected" : ""; ?>>Alberta</option>
                <option value='Saskatchewan' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Saskatchewan") ? "selected" : ""; ?>>Saskatchewan</option>
                <option value='Newfoundland & Labrador' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Newfoundland & Labrador") ? "selected" : ""; ?>>Newfoundland & Labrador</option>
                <option value='Nova Scotia' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Nova Scotia") ? "selected" : ""; ?>>Nova Scotia</option>
                <option value='Ontario' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Ontario") ? "selected" : ""; ?>>Ontario</option>
                <option value='British Columbia' <?php echo (isset($_POST["province"]) && $_POST["province"] == "British Columbia") ? "selected" : ""; ?>>British Columbia</option>
                <option value='Nunavut' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Nunavut") ? "selected" : ""; ?>>Nunavut</option>
                <option value='Yukon' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Yukon") ? "selected" : ""; ?>>Yukon</option>
                <option value='Northwest Territories' <?php echo (isset($_POST["province"]) && $_POST["province"] == "Northwest Territories") ? "selected" : ""; ?>>Northwest Territories</option>
            </select><br>

            <div class="captcha-div">
                <li>
                <br>
                    <img id="captcha" src="securimage/securimage_show.php" alt="CAPTCHA Image" />
                    </li>
                    <li>
                    <input type="text" name="captcha_code" size="10" maxlength="6" placeholder="Enter the code shown above..." />
                    <a href="#" onclick="document.getElementById('captcha').src = 'securimage/securimage_show.php?' + Math.random(); return false">[ Different Image ]</a>
                </li>
            </div>

            <div class='checkbox-div'>
            <label for="accept_terms">Accept Terms:</label> <input type='checkbox' id='accept_terms' name='accept_terms'><br>
            </div>
            <input type='submit' id='btnSubmit' name='btnSubmit' value='Submit'>
        </form>
    </div>
    </main>

    <footer>
        <div id="footer-div">
        <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
    </div>
    </footer>
</body>
</html>
