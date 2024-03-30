<?php
require_once('header.php');
require_once('form_check.php');

if(isset($_POST['btnSubmit'])) {
	$has_no_errors = checkVariablesForBlankFields($_POST)
	
	if ($has_no_errors) {
		echo 'Your form has been completed correctly.'
	} else {
		echo 'You have to provide all the information.'
	}
}
?>
<div id='form-div' method='post'>
	<form>
		<ul>
			<li>Name: <input type='text' id='name' name='name' value='<?php isset ($_POST['name']) ? $_POST['name'] : ""; ?>' /></li>
			<li>Email: <input type='text' id='email' name='email' value='<?php isset ($_POST['email']) ? $_POST['email'] : ""; ?>' /></li>
			<li>Password: <input type='password' id='password' name='password' value='<?php isset ($_POST['password']) ? $_POST['password'] : ""; ?>' /></textarea></li>
			<li><input type='submit' id='btnSubmit' name='btnSubmit' value='Send Values!'></li>
		</ul>
	</form>
</div>
<?php
require_once('footer.php');
?>