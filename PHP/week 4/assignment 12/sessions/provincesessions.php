<?php
//it is a good idea to put ob_start() and session_start()/session_destroy() in a config file (as the top part of the header), 
//just remember to put ob_flush() at the end of the document (footer)

//Output buffer holds headers in cache until ready to send out, this helps with functions that work with header
//otherwise you must do all work with headers above your HTML document declaration
	ob_start();
//Session start turns on sessions for the page which gives access to read and create session variables
//use session_unset(); and session_destroy(); to clear session information, must do the session destroy early.
//above your HTML headers to avoid errors depending on how online web servers are configured.
	session_start();
?>
<?php
	if(isset($_POST['clearsession'])) {
		session_unset();
		session_destroy();
		header("location: " . $_SERVER['PHP_SELF']);
		exit();
	}
	
?>

<?php
	require_once("php/header.php");
?>
<div id="container">
	<form method="post" action="<?php echo $_SERVER['PHP_SELF']; ?>">
		
		<?php 
		//COOKIES are stored on the client (local machine), use time limits to expire
		//SESSION is stored at the server or in the browser, encrypted and ends when browser window is closed.
		//must check for both cookie and session in this case, otherwise exception will occur
			if (isset($_SESSION['province'])) {
				echo "The province has been set by session is: " . $_SESSION['province'] . "<br>";
				} else if(isset($_POST['provsubmit']) && !empty($_POST['province'])) {
				$_SESSION['province'] = $_POST['province'];
				header("location: " . $_SERVER['PHP_SELF']);
				} else {
			?>
			<select name="province" id="province">
				<option value="">Select a province</option>
				<option value="AB">Alberta</option>
				<option value="BC">British Columbia</option>
				<option value="MA">Manitoba</option>
				<option value="NB">New Brunswick</option>
				<option value="NF">Newfoundland & Labrador</option>
				<option value="NT">Northwest Territories</option>
				<option value="NS">Nova Scotia</option>
				<option value="NV">Nunavut</option>
				<option value="ON">Ontario</option>
				<option value="PE">Prince Edward Island</option>
				<option value="QC">Quebec</option>
				<option value="SK">Saskatchewan</option>
				<option value="YK">Yukon</option>
			</select>
			
			<input type="submit" name="provsubmit" value="SEND">
			<?php
			}
		?>
		<?php
			if (isset($_SESSION['province'])) {
			?>
			<input type="submit" name="clearsession" value="Clear Session">
			<?php
			}
		?>
	</form>
</div>	
<?php
	require_once("php/footer.php");
?>
<?php ob_end_flush(); ?>