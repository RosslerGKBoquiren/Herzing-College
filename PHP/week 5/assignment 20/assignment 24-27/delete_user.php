<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Delete User</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>DELETE USER?</h1>
        </div>
    </header>

    <nav>
        <div class="menu">
             <span><a href="registration.php">REGISTRATION</a></span>
             <span><a href="table.php">LIST</a></span>
        </div>
    </nav>

    <div class="container">
        <?php
        $delete_id = -1;
        $output = "";

        if (!isset($_GET['id'])) {
            // Prevent direct access to delete_user.php without an ID
            header("location: table.php");
            exit(); // Stop execution
        } else {
            $delete_id = $_GET['id'];

            if (isset($_GET['confirm_delete'])) {
                // User has confirmed deletion
                if ($_GET['confirm_delete'] === 'yes') {
                    $database_connect = mysqli_connect('localhost', 'root', '', 'store')
                        or die("Error connecting to MySQL server.");

                    $query = "DELETE FROM users WHERE id=$delete_id";
                    $result = mysqli_query($database_connect, $query)
                        or die("Error in querying database");

                    if ($result) {
                        $output = "<div class='confirm_message'>Delete Successful</div>";
                    } else {
                        $output = "<div class='error_message'>Delete Unsuccessful</div>";
                    }

                    mysqli_close($database_connect);
                } else {
                    // User clicked "Cancel", redirect back to table.php
                    header("location: table.php");
                    exit(); 
                }
            } else {
                // User needs to confirm deletion
                $output = "<div class='confirm_message'>Are you sure you want to delete user with ID $delete_id?</div>";
                $output .= "<br>";
                $output .= "<a id='delete_btn' href='delete_user.php?id=$delete_id&confirm_delete=yes'>Delete</a> ";
                $output .= "<a id='cancel_btn' href='table.php'>Cancel</a>";
            }
        }

        // Output the confirmation message or result of deletion
        echo $output;
        ?>
    </div>
</body>
</html>




