//We don't want to use script tags in native javascript documents, only in HTML documents that include javascript

//here are some basic variables in javascript, declared with the 'var' keyword
var num1 = prompt("number 1", 0);//5;  //using a prompt to ask the user for a value
var num2 = prompt("number 2", 0);//7;  //using a prompt to ask the user for a value

var total = num1 + num2;

//Keep an eye on tabs for document structure in JavaScript
//tabs help to keep things organized.
//A lot of times we want to manipulate data from elements on a page.

//In order to access elements on the page we should use the window.onload event, 
//and assign a function to it. 
window.onload = function () {
    document.getElementById("contentId").innerHTML = total;
}

//if we want to do something when a button is clicked, we can create a function and then 
//call it from the button, or assign it to the button.