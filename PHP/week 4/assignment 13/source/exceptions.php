<?php
	try {
		//this will generate an exception as password is incorrect and exception now actually is caught.
		$dbc = mysqli_connect('localhost', 'storeuser', 'storeuser5', 'store')
		or die('Error connecting to MySQL server.');
		
		$query = "SELECT provincename FROM list";
		$result = mysqli_query($dbc, $query)
		or die('Error querying database.');
		
		while ($row = $result->fetch_row()){
			echo $row[0] . "<br/>";
		}
		
		mysqli_close($dbc);
		} catch (Exception $e) {
		echo "An error occoured. " . $e->getMessage() . "<br>";
	}
	echo "NEXT LINE" . "<br>";
?>

<?php
	try {
		// this will generate notice that would not be caught
		echo $someNotSetVariable;
		// fatal error that now actually is caught
		someNoneExistentFunction();
		
		} catch (Error $e) {
		echo "Error caught: " . $e->getMessage();
	}
	
	
?>