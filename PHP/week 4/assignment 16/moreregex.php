<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Regex Practice</title>
</head>

<body>
<?php
	//When we use preg_match() function with the third parameter $matches, PHP automatically
	// populates the $matches array with the matches found by the regular expression pattern.
	if (preg_match("/ell/", "Hello World!", $matches)) {
 	 	echo "Match was found <br />";
  		echo $matches[0];
		echo "<hr>";
	}
	
	if (preg_match("/ere.*/", "Something going on here", $matches)) {
	  echo "Match was found <br />";
	  echo $matches[0];
	  echo "<hr>";
	}
	//https://www.php.net/manual/en/regexp.reference.meta.php
	$email = "firstnAme_lastname@aaa.bbb.com";
	$regexp = "/^[^0-9][A-z0-9_]+([.][A-z0-9_]+)*[@][A-z0-9_]+([.][A-z0-9_]+)*[.][A-z]{2,4}$/";
	
	if (preg_match($regexp, $email)) {
		echo "Email address is valid.<span style=\"color:green\">&#10004;</span>";
	} else {
		echo "Email address is <u>not</u> valid.<span style=\"color:red\">&#10008;</span>";
	}
	echo
	"<pre>Cheatsheet:
		^ Start
		$ End
		[] Rules that are applied to a single character
		+ Apply the rule to everything ->
		\s Allow whitespace or spaces
		\d Allow all digits
		. Allow All
		\. Period
		{5} Apply rule to the next 5 characters
		{2,5} Apply rule to btween 2 and 5 characters
		* 0 or more quantifier
		
	</pre>";
?>
</body>
</html>