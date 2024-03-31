<?php
    //a couple of ways to declare arrays
    $list1 = array ('apples', 'bananas', 'oranges');
    
    //select an element based on index
    echo $list1[0] . "<br/>";
    
    //assigning to specific indexes, normally they start at 0
    $list2 = array (0 => 'apples', 1 => 'bananas', 2 => 'oranges');
    
    //add element to numeric index based array
    $list1[] = "pears";
    
    echo $list2[2] . "<br/>";
    
    //assigning key names for array elements
    $soups = array (
        'Monday' => 'Clam Chowder',
        'Tuesday' => 'White Chicken Chili',
        'Wednesday' => 'Vegetarian'
    );
    
    //add an element to the key based array of soups
    $soups["Thursday"] = "Minestrone";
    
    echo $soups['Tuesday'] . "<br/><br/>"; //outputs the element value stored at key 'Tuesday'
    
    //we can then use a loop to go through our array and process it,
    //in this case we will output each result.
    //echo $list1;failed
    for ($i = 0; $i < count($list1); $i++){
        echo "Element #" . $i . ": " . $list1[$i] . "<br/>";
    }
    
    echo "<br/><br/>";
    
    //the key function will return the key of that particular element
    //we can use a specific while loop to go through an array so we don't go outside 
    //the amount of elements available.
    //this is necessary if weve assigned our array elements to key values instead of using the index numbers (0, 1, 2...)
	echo "<h3>Associative Array Soups:</h3>";
    while ($soup_name = current($soups)) {
        echo key($soups) . "'s Soup Special is: " . $soup_name . '<br />';
        
        next($soups); //this moves us to the next element in the array
    }
    
    //we can also use the print_r() function to check the elements of an array
    echo "<br/><br/>First Array:";
    print_r($list1);
    echo "<br/><br/>Second Array:";
    print_r($list2);
    echo "<br/><br/>Third Array:";
    print_r($soups);    
    var_dump($soups);
?>