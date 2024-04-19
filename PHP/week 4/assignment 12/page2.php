<?php
	session_start();

	$name = $_SESSION['name'];
	$email = $_SESSION['email']
?>
<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>PHP Sessions</title>
</head>
<body>
	<h5>Thank you <?php echo $name; ?>, You have subscribed with the email <?php echo $email; ?></h5>
</body>
</html>