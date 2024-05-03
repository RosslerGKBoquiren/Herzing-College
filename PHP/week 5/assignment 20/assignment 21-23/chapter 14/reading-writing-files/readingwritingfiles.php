<html>
<head>Reading and Writing Files.</head>
<body>
<?php

//Select our file.
$file = "welcome.txt";

//Select the file and open it with a handle variable.
$handle = fopen($file, "r") or exit("Unable to open file!");

//Output a line of the file until the end is reached
while(!feof($handle)){
  	echo fgets($handle). "<br/>";
}

fclose($handle);

//We use "w" here to completely write new contents to the file.
$handle = fopen($file, 'w') or die('Cannot open file:  ' . $file);

//write some data here
$line = "New Data.";

fwrite($handle, $line);

fclose($handle);

//Here we use "a" to append to a file.
$my_file = "welcome.txt";

$handle = fopen($my_file, "a") or die("Cannot open file:  " . $my_file);

$line1 = "A line to append";

fwrite($handle, $line1);

$line2 = "\n" . "Another line to append.";

fwrite($handle, $line2);

fclose($handle);

//unlink($my_file); //- this is delete file function
?>
</body>
</html>