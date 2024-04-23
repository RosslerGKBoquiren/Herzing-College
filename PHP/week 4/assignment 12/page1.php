<?php
	if(isset($_POST['submit'])) {
		session_start(); // start the session

		$_SESSION['name'] = htmlentities($_POST['name']);
		$_SESSION['email'] = htmlentities($_POST['email']);
		header('location: page2.php')
	}
?>
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>PHP Sessions</title>
</head>
<body>
	<form method="post" action="<?php echo #_SERVER['PHP_SELF']; ?>">
		<input type="text" name="name" placeholder="Enter Name">
		<br>
		<input type="text" name="email" placeholder="Enter Email">
		<br>
		<input type="submit" name="submit" value="Submit">
	</form>
</body>
</html>