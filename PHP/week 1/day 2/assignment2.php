<?php require_once('header.php'); ?>
<div id='form-div'>
	<form method='post'>
		<ul>
			<li>Username: <input type='text' id='username' name='username'></li>
			<li>First Name: <input type='text' id='first_name' name='first_name'></li>
			<li>Last Name: <input type='text' id='last_name' name='last_name'></li>
			<li>Password: <input type='password' id='password' name='password'></li>
			<li>Confirm Password: <input type='password' id='confirm_password' name='confirm_password'></li>
			<li>Email: <input type='text' id='email' name='email'></li>
			<li>Province:
                <select id="province" name="province">
                    <option value='Manitoba'>Manitoba</option>
                    <option value='New Brunswick'>New Brunswick</option>
                    <option value='Prince Edward Island'>Prince Edward Island</option>
					<option value='Quebec'>Quebec</option>
					<option value='Alberta'>Alberta</option>
					<option value='Saskatchewan'>Saskatchewan</option>
					<option value='Newfoundland & Labrador'>Newfoundland & Labrador</option>
					<option value='Nova Scotia'>Nova Scotia</option>
					<option value='Ontario'>Ontario</option>
					<option value='British Columbia'>British Columbia</option>
					<option value='Nunavut'>Nunavut</option>
					<option value='Yukon'>Yukon</option>
					<option value='Northwest Territories'>Northwest Territories</option>
                </select>
            </li>
			<li>Accept Terms: <input type='checkbox' id='accept_terms' name='accept_terms'></li>
			<li><input type='submit' id='btnsubmit' name='btnsubmit' value='Submit'></li>
		</ul>
	</form>
</div>
<?php require_once('footer.php'); ?>

<?php
function calculate($number1, $number2, $operator = 'a')
{
    if ($operator == 's') {
        return $number1 - $number2;
    } elseif ($operator == 'd') {
        return $number1 / $number2;
    } elseif ($operator == 'm') {
        return $number1 * $number2;
    } else {
        return $number1 + $number2; // default addition
    }
}

echo calculate(36, 42);
?>

