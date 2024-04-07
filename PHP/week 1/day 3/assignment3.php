<?php
//create array of names called $names
$names = [
	'0' => 'Kobe', 
	'1' => 'Curry', 
	'2' => 'Lebron', 
	'3' => 'Kawai', 
	'4' => 'Howard', 
	'5' => 'Smith', 
	'6' => 'Rogers', 
	'7' => 'Banner', 
	'8' => 'Widow', 
	'9' => 'Frank'
	];

//create for loop names in order
for ($i = 0; $i < count($names); $i++) {
    echo "Name at position " . ($i + 1) . " is: " . $names[$i] . ".<br/>";
	}

echo '<hr>';
	
// create for loop names in reverse order 
for ($i = count($names) - 1; $i >= 0; $i--) {
    echo "Name at position " . (count($names) - $i) . " is: " . $names[$i] . ".<br/>";
	}
?>


<?php
echo '<hr>';
require_once('form_check.php');

if(isset($_POST['btnSubmit'])) {
    $has_no_errors = checkVariableforBlankFields($_POST);
    var_dump($_POST); // Added semicolon
    if ($has_no_errors) {
        echo 'Your form has been completed correctly.<br>';
        echo "Username: " . $_POST['username'] . "<br>";
        echo "Name: " . $_POST['first_name'] . " " . $_POST['last_name'] . "<br>";
        echo "Password: " . $_POST['password'] . "<br>";
        echo "Email: " . $_POST['email'] . "<br>"; // Corrected key
        echo "Accept Terms: ";
        if(isset($_POST['accept_terms']))
            echo "True";
        else
            echo "False";
        echo "<br>";
        
    } else {
        echo 'You have to provide all the information.';
    }
    var_dump($_POST); // Added semicolon
}
?>



<?php require_once('header.php'); ?>
<hr>
<div id='form-div'>
    <form method='post'>
        <ul>
            <li>Username: <input type='text' id='username' name='username' value='<?php echo isset($_POST["username"]) ? ($_POST["username"]) : ""; ?>'></li>
            <li>First Name: <input type='text' id='first_name' name='first_name' value='<?php echo isset($_POST["first_name"]) ? ($_POST["first_name"]) : ""; ?>'></li>
            <li>Last Name: <input type='text' id='last_name' name='last_name' value='<?php echo isset($_POST["last_name"]) ? ($_POST["last_name"]) : ""; ?>'></li>
            <li>Password: <input type='password' id='password' name='password' value='<?php echo isset($_POST["password"]) ? ($_POST["password"]) : ""; ?>'></li>
            <li>Confirm Password: <input type='password' id='confirm_password' name='confirm_password'></li>
            <li>Email: <input type='text' id='email' name='email' value='<?php echo isset($_POST["email"]) ? ($_POST["email"]) : ""; ?>'></li>
            <li>Province:
                <select id="province" name="province">
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
                </select>
            </li>
            <li>Accept Terms: <input type='checkbox' id='accept_terms' name='accept_terms'></li>
            <li><input type='submit' id='btnSubmit' name='btnSubmit' value='Submit'></li>
        </ul>
    </form>
</div>

<?php require_once('footer.php'); ?>
