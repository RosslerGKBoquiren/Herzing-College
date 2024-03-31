<?php require_once("php/header.php"); ?>
<?php

    //we can include files that contain functions as well.
    require_once("php/formcheck.php");    

    if (isset($_POST['btnSubmit'])) //using the isset() function to check to see if the button was pressed.
    {
        $hasNoErrors = checkVariablesForBlankFields($_POST); //this $hasNoErrors variable is different, than the one we saw in the function.
        //variables we create in a function are available only in that function.
        
        //with the result of the function we can check to see if the form was valid or not
        
        if ($hasNoErrors)
        {
            echo "Your form is correct. Submitting data to be saved.";
        }
        else
        {
            //always communicate with users to let them know if they made errors.
            //Try to be as clear as possible.
            echo "Your form is invalid. Please check your fields.";
        }
    }
?>
<div id="content">
    <form method="post" id="form1">
        <ul>
            <li>Name: <input type="text" name="name" id="name" value="<?php echo isset($_POST['name']) ? $_POST['name'] : ""; ?>" /></li>
            <li>Email: <input type="text" name="email" id="email" value="<?php echo isset($_POST['email']) ? $_POST['email'] : ""; ?>" /></li>
            <li>Password: <input type="password" name="password" id="password" value="<?php echo isset($_POST['password']) ? $_POST['password'] : ""; ?>" /></li>
            <li><input type="submit" name="btnSubmit" id="btnSubmit" value="Send Values!" /></li>
        </ul>
    </form>
</div>
<?php require_once("php/footer.php"); ?>