<?php require_once('header.php'); ?>

<?php
if (isset($_POST['btnsubmit']))
	(
		$name = $_POST['name'];
		$email = $_POST['email']
		$message = $_POST['message']
		$toAddress = '5276151@mtl.herzing.ca';
		$fromAddress = 'From: ';
		$subject = 'Contact through message.';
		
		echo $name . '\n'; 
		echo $email . '\n';
		echo $message . '\n';
		
		mail($toAddress, $subject, $message, $fromAddress);
	)
?>
<div id='form-div' method='post'>
	<form>
		<ul>
			<li> Name: <input type='text' id='name' name='name'></li>
			<li> Email: <input type='text' id='email' name='email'></li>
			<li> Message: <textarea id='message' name='message' col='50 row='4''></textarea></li>
			<li><input type='submit' id='btnsubmit' name='btnsubmit' value='Send Values!'></li>
		</ul>
	</form>
</div>
<?php require_once('footer.php'); ?>