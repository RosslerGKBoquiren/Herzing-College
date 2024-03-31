<?php
    //It can be useful as well to pass object like data along with an array.
    //Objects describe an entity, like a person, house, car, anything can be described in terms of objects.
    //You just have to think about the attributes you want to describe.    
    
    //Here we set up a person array and assign values to the key names.
    //This kind of structure is very similar to how database objects and javascript objects work.
    $person = array (
        'FirstName' => 'Joe',
        'LastName' => 'Franks',
        'EmailAddress' => 'joe@fakemail.com',
        'PhoneNumber' => '555-555-5555',
        'City' => 'Faketown'
    );
    
    //we don't have to initialize the array that way, we can create a new array then add the 
    //attributes ones by one also. 
    $person2 = array();
    $person2["FirstName"] = "Jeff";
    $person2["LastName"] = "Holmes";
    
    //When we process a person object, maybe they are logging in, so we can 
    //give them a welcome message.
    echo "Welcome back, " . $person2["FirstName"];
    
    //as opposed to selecting our elements by number which is a little more traditional, 
    //using key names can be a great way to make your code more readable, 
    //and make arrays easier to remember for processing.
?>