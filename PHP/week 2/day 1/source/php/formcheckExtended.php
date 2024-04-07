<?php
    //this function will take the values that the user posted and check to see 
    //if they were filled in. If any were not filled in then we will return false.
    //If they were all filled in, we return true.
    function checkVariablesForBlankFields($_POST){
        //creating hasNoErrors to keep track of if our form was filled in.
        $hasNoErrors = true;
        
        //creating variables to capture the $_POST information that was passed back from the form.
        //ADDED" filter_var with FILTER_SANITIZE flags. These will remove < and > and tag like characters
        //this is a security feature, and important to blocking any type of script injection.
        //hackers can add php or javascript in a form and wreak havoc on your site if you let them.
        $name = filter_var($_POST['name'], FILTER_SANITIZE_STRING);
        $email = filter_var($_POST['email'], FILTER_SANITIZE_EMAIL);
        $password = filter_var($_POST['password'], FILTER_SANITIZE_STRING);
        $province = $_POST['province']; //don't need filter_var for drop downs, radio buttons or check boxes, as the text doesn't come directly from the user.
        $radioChoice = $_POST['rdos']; 
        $checkAgreement = $_POST['checkagree'];
        
        if (empty($name)){ //calling the empty() function which will return true if empty, false if not
            $hasNoErrors = false;
            echo "Please fill in the name field. <br/>"; //let the user know they missed a field.
        }
                
        if (empty($email)){ //calling the empty() function which will return true if empty, false if not
            $hasNoErrors = false;
            echo "Please fill in the email field. <br/>"; //let the user know they missed a field.
        }
        //ADDED: check to make sure its a valid email
        else if (filter_var($email, FILTER_VALIDATE_EMAIL)){  
            $hasNoErrors = false;
            echo "Please use a valid email address <br/>"; //let the user know they are using an invalid email
        }
        
        if (empty($password)){ //calling the empty() function which will return true if empty, false if not
            $hasNoErrors = false;
            echo "Please fill in the password field. <br/>"; //let the user know they missed a field.
        }else{
            //hash your password before sending anywhere
            $password = sha1($password);
        }
        
        //ADDED: validation for drop down menu, radio buttons, and check boxes.
        
        //We use -1 for the error value of the drop down menu. 
        //These values come back as text so we will use a string.
        if ($province == "-1"){ 
            $hasNoErrors = false;
            echo "Please select a valid province. <br/>";
        }
        
        if ($radioChoice == null){
            $hasNoErrors = false;
            echo "Please select a radio button choice. <br/>";
        }
        
        //if needed you can check the check box. Otherwise record what the user selected.
        //A common scenario for this is agreeing to join a mailing list, which is optional.
        if ($checkAgreement == null){
            $hasNoErrors = false;
            echo "You must agree with our agreement to continue. <br/>";
        }
        
        if ($hasNoErrors){
            //once we validate we would send the data off to the database, 
            //or send an email, or save to a file.
            //here we will just output the data to the screen so we can test and see what it looks like.
            echo "Name: " . $name . "<br/>";
            echo "Email: " . $email . "<br/>";
            echo "Password: " . $password . "<br/>";
            echo "Province: " . $province . "<br/>";
            echo "Radio Button Choice: " . $radioChoice . "<br/>";
            echo "Agree with terms: " . $checkAgreement . "<br/>";
        }
        
        return $hasNoErrors; //return the result of isvalid so we can check it later.
    }
?>