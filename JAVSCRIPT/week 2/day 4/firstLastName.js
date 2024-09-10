let firstNameInput = document.getElementById("firstNameInput");
let lastNameInput = document.getElementById("lastNameInput");
let btnClick = document.getElementById("submitBtn");
let content = document.getElementById("content");
let btnReset = document.getElementById("resetBtn");

btnClick.addEventListener("click", function() {

    content.innerHTML = "";

    const firstName = firstNameInput.value;
    const lastName = lastNameInput.value;
    const nameRegex = /^[A-Za-z\s]+$/;

    if(!nameRegex.test(firstName) || !nameRegex.test(lastName)) {
        content.innerHTML = "Please enter a valid name.";
        return;
    } else {
        content.innerHTML = `Results: ${lastName}, ${firstName}.`;
    }
});


btnReset.addEventListener("click", function() {
    firstNameInput.value = "";
    lastNameInput.value = "";
    content.innerHTML = "";
})