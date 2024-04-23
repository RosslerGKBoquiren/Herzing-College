<?php

//We can use Regex to find and replace text.
//The contents of $message can come from anywhere, a form, a database, a file
//We will replace the word apple with orange.
$message = "I would like to buy 16 apples. 
            Please deliver the apples to my house. 
            Next week I would like to buy 24 more apples. Thank you.";

//the / and / surrounding apple in the example below mean that the text around the word 
//could be anything. This allows the word to be anywhere in the message and still be replaced.
$replaceMessage = preg_replace("/apple/", "orange", $message);
            
?>

<div style="width:300px;">
<?php echo $replaceMessage; ?>
</div>
