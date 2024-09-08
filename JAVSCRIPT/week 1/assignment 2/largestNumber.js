
let questionsDisplay = document.getElementById("questionsDisplay");
let stringUserInput = document.getElementById("userInput");
let buttonClick = document.getElementById("buttonClick");
let buttonReset = document.getElementById("buttonReset");
let largestNumberDisplay = document.getElementById("largestNumberDisplay");
let answers = [];
let maxQuestions = 5;

questionsDisplay.innerHTML = `#1. Enter a number: `;

buttonClick.addEventListener("click", function() {
    let intUserInput = parseFloat(stringUserInput.value);
    largestNumberDisplay.innerHTML = "";
    
    if(!isNaN(intUserInput)) {
        answers.push(intUserInput);
        stringUserInput.value = "";

        for (let i = answers.length + 1; i <= maxQuestions; i++) {
            if (answers.length < maxQuestions) {
                questionsDisplay.innerHTML = `#${i}. Enter a number: `;
                break;
            }
        }

        if (answers.length === maxQuestions) {
            let largestNumber = Math.max(...answers);
            largestNumberDisplay.innerHTML = `Your largest number is: ${largestNumber}!`;
            stringUserInput.disabled = true; 
            buttonClick.disabled = true; 
        }
    } else {
        largestNumberDisplay.innerHTML = `Invalid input! Please enter a valid number.`; 
    }
});

buttonReset.addEventListener("click", function() {
    answers = [];
    questionsDisplay.innerHTML = `#1. Enter a number: `; 
    largestNumberDisplay.innerHTML = ""; 
    stringUserInput.value = ""; 
    stringUserInput.disabled = false; 
    buttonClick.disabled = false; 
});
    