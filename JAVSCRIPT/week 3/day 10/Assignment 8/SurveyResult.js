
// Variable error message
let errormsg;

let usermsg = document.getElementById("usermsg");
let email = document.getElementById("email");
let age = document.getElementById("age");
let red = document.getElementById("red");
let blue = document.getElementById("blue");
let green = document.getElementById("green");
let submitform = document.getElementById("submitform");

// Custom Javascript object
function SurveyUser(array) {
    this.email = array["email"];
    this.age = array["age"];
    this.choice = array["choice"];

    // successful validation format msg
    this.sayResult = function () {
        usermsg.innerHTML = `Success! <br><br> Thank you for taking the survey.<br><br> Here are your results:<br><br>
        Email: ${this.email}<br><br>
        Age: ${this.age}<br><br>
        Choice: ${this.choice}`;
        usermsg.style.color = "green";
    };
}

submitform.addEventListener("click", function () {
    event.preventDefault();

    const email_regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
    let choice;

    errormsg = "";
    usermsg.innerHTML = "";

    if (email.value === "" || !email_regex.test(email.value)) {
        errormsg += "Please enter a valid email!<br>"; // Collecting error msgs
    }

    if (age.value === "" || isNaN(age.value) || age.value < 1 || age.value > 100) {
        errormsg += "Please enter a valid age!<br>"; // collecting error msgs
    }

    if (red.checked) {
        choice = red.value;
    } else if (blue.checked) {
        choice = blue.value;
    } else if (green.checked) {
        choice = green.value;
    } else {
        errormsg += "Please select a color!<br>"; // collecting error msgs
    }

    if(errormsg !== "") {
        usermsg.innerHTML = errormsg; // injecting error msgs to usermsg div
        usermsg.style.color = "red";
        return;
    }

    let user = new SurveyUser({
        email: email.value,
        age: age.value,
        choice: choice
    });

    user.sayResult();
});
