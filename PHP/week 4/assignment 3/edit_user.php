<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Edit User</title>
    <link rel="stylesheet" type="text/css" href="style.css">
</head>
<body>
    <header>
        <div class="header">
            <h1>EDIT USER</h1>
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
        $edit_id = -1;
        $output = "";

        if (!isset($_GET['id'])) {
            // Prevent direct access to edit_user.php without an ID
            header("location: table.php");
            exit(); // Stop execution
        } else {
            $edit_id = $_GET['id'];

            if (isset($_GET['confirm_edit'])) {
                // User has confirmed edit
                if ($_GET['confirm_edit'] === 'yes') {
                    // Redirect to edit form page with user ID
                    header("location: edit_form.php?id=$edit_id");
                    exit(); 
                } else {
                    // User clicked "Cancel", redirect back to table.php
                    header("location: table.php");
                    exit(); 
                }
            } else {
                // User needs to confirm edit
                $output = "<div class='confirm_message'>Are you sure you want to edit user with ID $edit_id?</div>";
                $output .= "<br>";
                $output .= "<a id='edit_btn' href='edit_user.php?id=$edit_id&confirm_edit=yes'>Edit</a> ";
                $output .= "<a id='cancel_btn' href='table.php'>Cancel</a>";
            }
        }

        // Output the confirmation message or result of edit
        echo $output;
        ?>
    </div>
</body>
</html>
