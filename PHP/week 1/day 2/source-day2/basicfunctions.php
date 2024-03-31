<?php
    $name = "Steve"; // a name variable, the type is "string" which represents text.
    $age = 35; // an age variable, the type is integer, and it represents whole numbers.
    $price = 55.99; // a price variable, the type is float (decimal) and it represents decimal numbers
    
    //Lets create a message to print out in our upcoming function and use the variables provided.
    
    $message = ""; //initialize the message variable.
    
    //here we use .= (dot equals), a compound operator.
    //this will keep what was already in the message variable and add in $name
    $message .= $name; 
    
    $message .= " is " . $age . " years old and sells shoes for $" . $price . "<br/>";
    
    $message2 = "If " . $name . "'s age is doubled, it would be " . ($age * 2);   //this takes the age and multiplies by two.
    //you can put math in brackets to make sure you get the result before its added to the string, 
    //but the best practice is to do math is on another variable itself.
    
    //you can perform math on numbers. Use +, -, * and / operators for basic math.
    
    $doubledPrice = $price * 2; //mutliplication
    $addedPrice = $price + 2;
    $subtractedPrice = $price - 2;
    $dividedPrice = $price / 2; //division
    
    //to keep numbers values and add to them, use compound operators.
    $price += 5; //this is the same as saying $price = $price + 5;
    $price -= 5; //this is the same as saying $price = $price - 5;
    $price /= 5; //this is the same as saying $price = $price / 5;
    $price *= 5; //this is the same as saying $price = $price * 5;
        

    function doNothing(){
        //this is a basic function. 
        //it takes no parameters (the values in the brackets)
        //and literally does nothing.
        //be aware of its form, notice the opening and closing squiggly brackets { and } 
        //These denote a block of code in php. Keep an eye on where these are to not get them 
        //confused with others
        //the function name should describe the function somewhat
        //a function can take in values (parameters) process them and then
        //return a value as well. It just depends on what you want to do.
        //Lets create a function that does something common, such as check a form for user input.
        //This is something we will need plenty of practice with so we will start small and grow.
    }
    
    doNothing(); //here we call the function on load but it won't do anything.
    
    function showMessage($message){
        //this function takes a message and displays it on the screen.
        echo $message . "<br/>"; //set a new line after the message so no other content is stuck to it.
        //notice the dot after $message, this will connect two strings (text values) together. 
        //you can use this to combine variable values with text.
    }
    
    showMessage("This message was loaded from the \"showMessage()\" function!<br>"); //testing the message on page load
    showMessage($message);
    showMessage($message2);
?>