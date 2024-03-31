<?php

//For loop structure
//for (initial expression; condition; closing expression) {
    //statement(s);
//}    

//this basic loop starts an iterator variable ($i)
//then sets a condition that $i remain less than or equal to 10
//then the closing expression determines the amount the iterator will iterate 
for ($i = 1; $i <= 10; $i++) { //the ++ in the iterator means go up by 1
    echo $i . "<br/>";
}

echo "<hr>";
// this loop is reversed from above
for ($i = 10; $i >= 1; $i--) { //the -- in the iterator means go down by 1
    echo $i . "<br/>";
}

?>