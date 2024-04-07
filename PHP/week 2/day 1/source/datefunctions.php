<?php
    //get a basic date - without a supplied date it will just display the current date by default
    echo date("M/d/Y") . "<br/><br/>";
    
    //change the format
    echo date("d/M/Y") . "<br/><br/>";
    
    //show the time
    echo date("d/M/y H:m:s") . "<br/><br/>";
    
    //TimeStamps - Use this type in a database to make saving dates to the database easier
	$date1 = date("Y/m/d H:i:s"); 
	$date1ts = strtotime($date1); 
	echo "Date and Time Generated from PHP: " . $date1 . "<br/><br/>";
	echo "Date and Time converted to UNIX Timestamp: " . $date1ts . "<br/><br/>";
	echo "Date and Time converted back from Timestamp: " . strftime("%Y/%m/%d %H:%M:%S", $date1ts) . "<br/><br/>";
    
    //See http://ca3.php.net/manual/en/function.date.php for more format options
?>