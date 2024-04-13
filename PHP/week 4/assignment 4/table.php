<!DOCTYPE html>
<html lang="en">
<head>
	<meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>USER LIST</title>
	<link rel="stylesheet" type="text/css" href="style.css">	
</head>
<body>

	<header>
		<div class="header">
			<h1>USER LIST</h1>
		</div>
	</header>

	<nav>
		<div class="menu">
			 <span><a href="registration.php">REGISTRATION</a></span>
			 <span><a href="table.php">LIST</a></span>
		</div>
	</nav>

	<main>
    <?php
    $database_connect = mysqli_connect('localhost', 'root', '', 'store')
        or die ("Error connecting to MySQL server.");

    $query = "SELECT * FROM users"; 
    $result = mysqli_query($database_connect, $query)
        or die ("Error in querying database");

    $output = "";
    $output .= "<table class='table' id='table'>";
    $output .= "<tr>" .
                "<th>ID</th>" .
                "<th>Username</th>" . 
                "<th>First name</th>" . 
                "<th>Last name</th>" .
                "<th>Password</th>" .
                "<th>Province</th>" .
                "<th>Email</th>" .
                "<th>Date Joined</th>" .
                "<th>Edit</th>" .
                "<th>Delete</th>" .
                "</tr>";

    while ($row = $result->fetch_row()) {
        $output .= "<tr>";
        $output .= "<td>" . $row[0] . "</td>";
        $output .= "<td>" . $row[1] . "</td>";
        $output .= "<td>" . $row[2] . "</td>"; 
        $output .= "<td>" . $row[3] . "</td>"; 
        $output .= "<td>" . $row[4] . "</td>"; 
        $output .= "<td>" . $row[5] . "</td>"; 
        $output .= "<td>" . $row[6] . "</td>"; 
        $output .= "<td>" . $row[7] . "</td>"; 
        $output .= "<td>" . "<a id='edit' href='edit_user.php?id=" . $row[0] . "'>Edit</a>" . "</td>"; // edit_user.php not ready yet
        $output .= "<td>" . "<a id='delete' href='delete_user.php?id=" . $row[0] . "'>Delete</a>" . "</td>"; 
        $output .= "</tr>";
    }
    mysqli_close($database_connect);

    $output .= "</table>"; 

    echo $output;
    ?>
	</main>

	<footer>
		<div id="footer-div">
        <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
    </div>
	</footer>
</body>
</html>