<?php 
	//For variables we want to be avaiable to the whole document we should define them here.
	//Just make sure there are no spaces between the beginning of line 1 of the document,
	//and the opening PHP tag. This can cause problems down the line when we get into some more advanced activities.
	$output = ""; 
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>Selecting and Inserting Province Records</title>
</head>

<body>
<?php 


	if (isset($_POST['provsubmit'])){
		$provincename = $_POST['provincename'];
		$isvalid = true;
		//call the captcha files here
		require_once 'securimage/securimage.php';
		$securimage = new Securimage(); //instance of the Secure Image Class
		
		//validate
		//Securimage Validation.
		if ($securimage->check($_POST['captcha_code']) == false) {
			$output .= "The security code entered was incorrect.<br /><br />";
			$output .= "Please go <a href='javascript:history.go(-1)'>back</a> and try again.";	
			$isvalid = false;
		}
		
		if ($provincename == ""){
			$isvalid = false;
			$output .= "Please input the province name you want to submit.<br/>";
		}
		
		if ($isvalid){
			//insert record
			$dbc = mysqli_connect('localhost', 'storeuser', 'storeuser55', 'store')
			or die('Error connecting to MySQL server.');
	
			$query = "INSERT INTO list VALUES (NULL, '$provincename')";
			$result = mysqli_query($dbc, $query)
			or die('Error querying database.');		
			
			mysqli_close($dbc);		
			
			if ($result){
				$output .= "Record inserted Successfully.<br/>";
			}else{
				$output .= "Record insertion Unsuccessful.<br/>";
			}
		}
	}

//Get all the existing province records. This happens every time.
//We are doing this after the button submission check so we will see a new province 
//right after inserting into the database, and we don't have to refresh the page.
$dbc = mysqli_connect('localhost', 'storeuser', 'storeuser55', 'store')
or die('Error connecting to MySQL server.');

$query = "SELECT provincename FROM list";
$result = mysqli_query($dbc, $query)
or die('Error querying database.');

while ($row = $result->fetch_row()){
	echo $row[0] . "<br/>"; //we are only getting one field back so we know 0 = provincename. 
	//The list of variables that comes back in the $row array are 0 based and go in the order of either the 
	//database table (if * rows are specified) or the order you request them in in your query (if you name specific fields)
}

mysqli_close($dbc);
echo "<br/>";

?>

<form action="<?php echo $_SERVER["PHP_SELF"]; ?>" method="post" >
<ul>
	<li>
    	<?php if ($output != "") echo $output; ?>
    </li>
	<li>
		<input type="text" name="provincename" id="provincename" />    
    </li>
    <li> Please input the following text below: *</br>
				<img id="captcha" src="securimage/securimage_show.php" alt="CAPTCHA Image" />
			</li>
    <li>
				<input type="text" name="captcha_code" size="10" maxlength="6" />
				<a href="#" onclick="document.getElementById('captcha').src = 'securimage/securimage_show.php?' + Math.random(); return false">[ Different Image ]</a>
	</li>
    <li>
    	<input type="submit" name="provsubmit" id="provsubmit" value="Submit"/>
    </li>
</ul>
</form>

</body>
</html>