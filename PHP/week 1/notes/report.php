<!DOCTYPE html>
<html>
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Aliens Abducted Me - Report an Abduction</title>
</head>
<body>
	<h2>Aliens Abducted Me - Report an Abduction</h2>

	<<?php 
		$when_it_happened = $_POST['whenithappened'];
		$how_long = $_POST['description'];
		$alien_description = $_POST['fangspotted'];
		$email = $_POST['email'];

		echo "Thanks for submitting the form.<br />";
		echo "You were abducted " . $when_it_happened;
		echo " and were gone for " . $how_long . '<br />';
		echo "Describe them: "; . $aliendescription . '<br />';
		echo "Was Fang there? " . $fang_spotted . '<br />';
		echo "Your email address is " . $email;
	 ?>
</body>
</html>