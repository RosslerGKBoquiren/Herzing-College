<?php
require_once('header.php')
?>
$name = 'Rogers'
$age = 25;
$price = 8.69;
$message = '';

$message .= $name;
$message .= ' is' . $age . 'years old';
$message .= ' and he sells shoes for $' . $price . '\n';
 
$message2 = $name . "'s age after multiplication by 2 is " . $age * 2;

$double_price = $price * 2;
$added_price = $price + 2;

$price += 5;
$price = $price + 5;
$price -= 5;
$price *= 5;
$price /= 5;

function doNothing()
{
	echo 'Do nothing';
};

doNothing();


function showMessage($msg)
{
	echo $msg . '\n';
}

showMessage("This message was loaded by calling function \"showMessage()\".");
showMessage ($message);
showMessage ($message2);
<?php
require_once('header.php')
?>