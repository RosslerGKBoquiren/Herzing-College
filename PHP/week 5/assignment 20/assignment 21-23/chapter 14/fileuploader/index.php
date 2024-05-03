<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>File Uploader</title>
</head>

<body>
<?php 
	/*This script displays and handles an HTML form. This script takes a file upload and stores it on the server.*/
	
	if ($_SERVER['REQUEST_METHOD'] == 'POST'){
		// Handle the form.
		
		//Try to move the uploaded file.
		if (move_uploaded_file($_FILES['the_file']['tmp_name'], "uploads/{$_FILES['the_file']['name']}")){
			$filepath = $_FILES['the_file']['name'];
			echo '<p>Your File Has Been Uploaded.</p>'; ?>
				<img src="<?php echo "uploads/$filepath"; ?>" width="300" />
	<?php
		}else{ //Problem uploading file.
			
			print '<p style="color:red;">Your file could not be uploaded because: <br/>';
			
			//Print a message based upon the error:
			switch($_FILES['the_file']['error']){
				case 1:
					print 'The file exceeds the upload_max_filesize setting in php.ini';
					break;
				case 2:
					print 'The file exceeds the MAX_FILE_SIZE setting in the HTML form';
					break;
				case 3:
					print 'The file was only partially uploaded';
					break;
				case 4:
					print 'No file was uploaded';
					break;
				case 6:
					print 'The temporary folder does not exist';
					break;
				default:
					print 'Something unforeseen happened';
					break;
				} //End of switch
				
			print '. </p>';
		} //End of move_uploaded_file() IF
	} // End of Submission IF
	
	//Leave PHP and display the form.
?>

<form action="index.php" enctype="multipart/form-data" method="post">
	<p>Upload a file using this form:</p>
    <input type="hidden" name="MAX_FILE_SIZE" value="300000" />
    <p><input type="file" name="the_file" /></p>
    <p><input type="submit" name="submit" value="Upload This File" /></p>
</form>
</body>
</html>
