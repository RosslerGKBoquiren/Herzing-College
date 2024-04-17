<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>REGISTRATION FORM</title>
	<link rel="stylesheet" type="text/css" href="style.css">	
</head>
<body>

	<header>
		<div class="header">
			<h1>REGISTRATION FORM</h1>
		</div>
	</header>

	<nav>
		<div class="menu">
			 <span><a href="#">REGISTRATION</a></span>
			 <span><a href="table.php">LIST</a></span>
		</div>
	</nav>

	<main>
    <?php
    require_once('form_check.php');

    if(isset($_POST['btnSubmit'])) {
        // add validation code
        // check all fields are required
        if(empty($_POST['username']) || empty($_POST['first_name']) || empty($_POST['last_name']) || empty($_POST['password']) || empty($_POST['confirm_password']) || empty($_POST['email']) || empty($_POST['province']) || !isset($_POST['accept_terms'])) {
            // if user misses a field, form won't output. Message to appear
            echo '<div class="output_message error_message">You have to provide all the information.</div>'; //output messages are in divs for style purposes
        } else {
            //proper email validation 
            if (!filter_var($_POST['email'], FILTER_VALIDATE_EMAIL)) {
                echo '<div class="output_message error_message">Invalid email address format.</div>'; //output messages are in divs for style purposes
            } else {
                /* // output the same as in previous assignment
                echo '<div class="output_message success_message">'; //output messages are in divs for style purposes
                echo 'Your form has been completed correctly.<br>';
                echo "Username: " . $_POST['username'] . "<br>";
                echo "Name: " . $_POST['first_name'] . " " . $_POST['last_name'] . "<br>";
                echo "Password: " . $_POST['password'] . "<br>";
                echo "Email: " . $_POST['email'] . "<br>";
                echo "Province: " . $_POST['province'] . "<br>";
                echo "Accept Terms: " . (isset($_POST['accept_terms']) ? 'True' : 'False') . "<br>";
                echo '</div>'; */
                
                // Connect to the database
                $database_connect = mysqli_connect('localhost', 'root', '', 'store')
                or die ('Error connecting to MySQL server.');
                
                // prepare data
                $username = mysqli_real_escape_string($database_connect, $_POST['username']);
                $first_name = mysqli_real_escape_string($database_connect, $_POST['first_name']);
                $last_name = mysqli_real_escape_string($database_connect, $_POST['last_name']);
                $password = mysqli_real_escape_string($database_connect, $_POST['password']);
                $email = mysqli_real_escape_string($database_connect, $_POST['email']);
                $province = mysqli_real_escape_string($database_connect, $_POST['province']);
                
                // insert data into database
                $query = "INSERT INTO users (username, first_name, last_name, password, email, province) 
                    VALUES ('$username', '$first_name', '$last_name', '$password', '$email', '$province')";
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
    ?>

    <div id='form-div'>
    <form class='form' method='post'>
        <label for="username">Username:</label> <input type='text' id='username' name='username' placeholder='Enter your Username...' value='<?php echo isset($_POST["username"]) ? ($_POST["username"]) : ""; ?>'><br>
        <label for="first_name">First Name:</label> <input type='text' id='first_name' name='first_name' placeholder='Enter your First Name...' value='<?php echo isset($_POST["first_name"]) ? ($_POST["first_name"]) : ""; ?>'><br>
        <label for="last_name">Last Name:</label> <input type='text' id='last_name' name='last_name' placeholder='Enter your Last Name...' value='<?php echo isset($_POST["last_name"]) ? ($_POST["last_name"]) : ""; ?>'><br>
        <label for="password">Password:</label> <input type='password' id='password' name='password' placeholder='Enter your Password...' value='<?php echo isset($_POST["password"]) ? ($_POST["password"]) : ""; ?>'><br>
        <label for="confirm_password">Confirm Password:</label> <input type='password' id='confirm_password' name='confirm_password' placeholder='Confirm your Password...'><br>
        <label for="email">Email:</label> <input type='text' id='email' name='email' placeholder='Enter your Email...' value='<?php echo isset($_POST["email"]) ? ($_POST["email"]) : ""; ?>'><br>
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