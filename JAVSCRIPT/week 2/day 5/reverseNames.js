
let namesInput = document.getElementById("userInput");
let reverseBtnClick = document.getElementById("reverseNamesBtn");
let namesArray = [];
let reverseNamesArray = [];
let maxNumberNames = 5;
let results = document.getElementById("results");
let originalResults = document.getElementById("originalResults");
let questionsDisplay = document.getElementById("questionsDisplay");
let resetBtn = document.getElementById("resetBtn");

questionsDisplay.innerHTML = `Enter Name #1: `;

reverseBtnClick.addEventListener("click", function() {

    results.innerText = "";

    const names = namesInput.value;
    const namesRegex = /^[A-Za-z\s]+$/;

    if (!namesRegex.test(names)) {
        results.innerText = "Please enter a valid name."
        return; 
    } else {
        namesArray.push(names);
    }
        namesInput.value = "";

    /*for (let i = namesArray.length + 1; i <= maxNumberNames; i++) {
        if (namesArray.length < maxNumberNames) {
            questionsDisplay.innerHTML = `Enter Name #${i}: `;
            break;
        }
    }*/


    if (namesArray.length < maxNumberNames) {
        questionsDisplay.innerHTML = `Enter Name #${namesArray.length + 1}: `;
    }
        

    if (namesArray.length === maxNumberNames) {
        reverseNamesArray.push(...[...namesArray].reverse())
        originalResults.innerHTML = `Original Results: ${namesArray.join(", ")}`;
        results.innerHTML = `Reversed Results: ${reverseNamesArray.join(", ")}`;

        namesInput.disabled = true;
        reverseBtnClick.disabled = true;
    }
});


resetBtn.addEventListener("click", function() {
    namesInput.value = "";
    namesArray = [];
    reverseNamesArray = [];
    originalResults.innerHTML = "";
    results.innerHTML = "";
    questionsDisplay.innerHTML = `Enter Name #1: `;

    namesInput.disabled = false;
    reverseBtnClick.disabled = false;
})