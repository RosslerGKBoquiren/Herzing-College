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

    <main>
        <?php
        $database_connect = mysqli_connect('localhost', 'root', '', 'store') 
            or die('Error connecting to MySQL server.');

        if (isset($_GET['id'])) {
            $edit_id = $_GET['id'];

            $query = "SELECT id, username, first_name, last_name, province, email FROM users WHERE id=$edit_id";
            $result = mysqli_query($database_connect, $query) 
                or die('Error querying database.');

            // Check if the user exists
            if (mysqli_num_rows($result) > 0) {
                $row = mysqli_fetch_assoc($result);
                $id = $row['id'];
                $username = $row['username'];
                $first_name = $row['first_name'];
                $last_name = $row['last_name'];
                $province = $row['province'];
                $email = $row['email'];

                // Array of Canadian provinces
                $provinces = array(
                    "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland and Labrador",
                    "Nova Scotia", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan",
                    "Northwest Territories", "Nunavut", "Yukon"
                );

                // Check if form is submitted
                if (isset($_POST['btnSubmit'])) {
                    // Update the database with new values
                    $new_username = strip_tags($_POST['username']);
                    $new_first_name = strip_tags($_POST['first_name']);
                    $new_last_name = strip_tags($_POST['last_name']);
                    $new_province = strip_tags($_POST['province']);
                    $new_email = strip_tags($_POST['email']);
                    $query = "UPDATE users SET username='$new_username', first_name='$new_first_name', last_name='$new_last_name', province='$new_province', email='$new_email' WHERE id=$edit_id";
                    $result = mysqli_query($database_connect, $query) 
                    or die('Error updating database.');

                    // Check if update was successful
                    if ($result) {
                        echo '<div class="confirm_message">Update Successful</div>';
                    } else {
                        echo '<div class="confirm_message">Update Unsuccessful</div>';
                    }
                }
        ?>

        <div id='form-div'>
            <form class='form' method="post">
                <label for="username">Username:</label>
                <input type="text" id="username" name="username" value="<?php echo $username; ?>" required><br>
                <label for="first_name">First Name:</label>
                <input type="text" id="first_name" name="first_name" value="<?php echo $first_name; ?>" required><br>
                <label for="last_name">Last Name:</label>
                <input type="text" id="last_name" name="last_name" value="<?php echo $last_name; ?>" required><br>
                <label for="province">Province:</label>
                <select id="province" name="province" required>
                    <?php
                    // Output options for each province
                    foreach ($provinces as $prov) {
                        if ($prov === $province) {
                            echo "<option value='$prov' selected>$prov</option>";
                        } else {
                            echo "<option value='$prov'>$prov</option>";
                        }
                    }
                    ?>
                </select><br>
                <label for="email">Email:</label>
                <input type="email" id="email" name="email" value="<?php echo $email; ?>" required><br>
                <input type="submit" id='btnSubmit' name="btnSubmit" value="Update">
            </form>
        </div>

        <?php
            } else {
                echo '<div class="confirm_message">User not found.</div>';
            }
        } else {
            echo '<div class="confirm_message">ID not provided.</div>';
        }

        mysqli_close($database_connect);
        ?>
    </main>

    <footer>
        <div id="footer-div">
            <p>&copy; <?php echo date("Y"); ?> Rossler Boquiren</p>
        </div>
    </footer>
</body>
</html>

