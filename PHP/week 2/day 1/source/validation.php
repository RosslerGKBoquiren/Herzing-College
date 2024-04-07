<?php
//filter_var is useful for operations like checking an email address, IP address or if an integer is an integer.
//they can simplify the work for you and represent solid ways to validate provided by the makers of PHP
//(its built in!)

//in addition to this lesson check out http://php.net/manual/en/filter.examples.validation.php
// and http://www.php.net/manual/en/filter.filters.validate.php for the complete filters list

//We will start with values to test the filter_var function.
//filter_var takes the value we want to test,
//followed by a filter variable that describes the type of validation we want to do.
// it is the best method for validating email in PHP

//filter_var returns true or false depending on whether or not the data is valid.

$email_a = 'joe@example.com';
$email_b = 'bogus';

if (filter_var($email_a, FILTER_VALIDATE_EMAIL)) {
    echo "This (email_a) email address is considered valid.";
}
if (filter_var($email_b, FILTER_VALIDATE_EMAIL)) {
    echo "This (email_b) email address is considered valid.";
}

$int_a = '1';
$int_b = '-1';
$float_a = '44.22';

if (filter_var($int_a, FILTER_VALIDATE_INT)) {
    echo "This is a valid integer.";
}
if (filter_var($int_b, FILTER_VALIDATE_INT)) {
    echo "This is a valid integer.";
}
if (filter_var($int_c, FILTER_VALIDATE_FLOAT)) {
    echo "This is a valid float.";
}



?>
