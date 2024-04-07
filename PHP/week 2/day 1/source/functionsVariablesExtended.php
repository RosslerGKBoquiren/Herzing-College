<?php require_once("php/header.php"); ?>
<?php

    //we can include files that contain functions as well.
    require_once("php/formcheckExtended.php");    

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
            <li>Province:  <!-- ADDED -->
                <select name="province">
                    <option value="-1">Select A Province</option>
                    <option value="AB">Alberta</option>
                    <option value="BC">British Columbia</option>
                    <option value="NS">Nova Scotia</option>
                </select>
            </li>
            <li>
                Choice1: <input type="radio" name="rdos" id="rdo1" value="Choice1" />
                Choice2: <input type="radio" name="rdos" id="rdo2" value="Choice2" />
            </li>
            <li>
                Do you agree with terms? <input type="checkbox" name="checkagree" id="checkagree" />
            </li>
            <li><input type="submit" name="btnSubmit" id="btnSubmit" value="Send Values!" /></li>
        </ul>
    </form>
</div>
<?php require_once("php/footer.php"); ?>