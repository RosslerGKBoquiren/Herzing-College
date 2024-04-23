<?php 
//we can set configuration settings (which would normally be in php.ini, the main php config file)
//using the ini_set function. In this case we can hide all errors 
//the @ symbol supresses errors as well, so if the server is restricted and won't allow ini_set functions,
//you can still supress those errors. 

//Here we turn on the log, and we give it a specific file location.
//This way our production server that the public sees will not see PHP errors,
// and we can still keep track of them by checking the log file.
@ini_set('log_errors','on'); // enable or disable php error logging (use 'On'/'Off' or 1/0)
@ini_set('display_errors','off'); // enable or disable public display of errors (use 'On' or 'Off')
@ini_set('error_log','logs/log'); // path to server-writable log file 
								//(create it and make sure it has the right permissions)

//sending all errors to error_log

try {
	$dbc = mysqli_connect('localhost', 'storeuser', 'storeuser5', 'ssstore')
		or die('Error connecting to MySQL server.');
		//mysqli_connect('dfgfdstg');
		//and many more lines of codes
} catch (Exception $e) {
	echo error_log($e->getMessage(), 3, "logs/log");
	//error_log returns true (1) on success and false (0) on failure.

}


?>