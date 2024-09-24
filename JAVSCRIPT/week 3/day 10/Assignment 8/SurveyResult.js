
let errormsg;

let usermsg = document.getElementById("usermsg");
let email = document.getElementById("email");
let age = document.getElementById("age");
let red = document.getElementById("red");
let blue = document.getElementById("blue");
let green = document.getElementById("green");
let submitform = document.getElementById("submitform");

function SurveyUser(array) {
    this.email = array["email"];
    this.age = array["age"];
    this.color = array["color"];
    this.choice = array["choice"];

    this.sayResult = function () {
        usermsg.innerHTML = `Success! <br><br> Thank you for taking the survey.<br><br> Here are your results:<br><br>
        Email: ${this.email}<br><br>
        Age: ${this.age}<br><br>
        Color: ${this.color}<br><br>
        Choice: ${this.choice}`;
        usermsg.style.color = "green";

        this.checkCookie(this.color); // Checking cookie after displaying results
        
    };

    this.checkCookie = function (chosenColor) {
        let selectedColor = getCookie("selectedColor");
        if (selectedColor !== "") {
            usermsg.innerHTML += `<br><br>Your selected color from the cookie is: ${selectedColor}.`;
        } else {
            usermsg.innerHTML += `<br><br>No color cookie was set.`;
        }
    };
}

// Set the selected color in a cookie to expire in 1 day
function setCookie(cname, cvalue, exdays) {
    let date = new Date();
    date.setTime(date.getTime() + (exdays * 24 * 60 * 60 * 1000)); // Cookie expires in 1 day
    let expires = `expires=${date.toUTCString()}`;

    document.cookie = `${cname}=${cvalue}; ${expires}; path=/`;
    
    console.log(`Cookie set: ${cname}=${cvalue}; Expires: ${expires}`);
}

// Retrieve the cookie value by name
function getCookie(cname) {
    let name = `${cname}=`;
    let decodedCookie = decodeURIComponent(document.cookie); // Get all cookies
    let cookieArray = decodedCookie.split(';'); // Split cookies by ';'

    
    console.log(`Full cookie array: ${cookieArray}`);

    for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i].trim(); // Remove spaces
        if (cookie.indexOf(name) === 0) {
            return cookie.substring(name.length, cookie.length); // Return cookie value
        }
    }
    return ""; // Return empty string if cookie not found
}

submitform.addEventListener("click", function (event) {
    event.preventDefault();

    errormsg = "";
    usermsg.innerHTML = "";

    try {
        const email_regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        let choice;
        let color = document.getElementById("color").value; // Retrieve the selected color
        

        // Email validation
        if (email.value === "" || !email_regex.test(email.value)) {
            errormsg += "Please enter a valid email!<br>";
        }

        // Age validation
        if (age.value === "" || isNaN(age.value) || age.value < 1 || age.value > 100) {
            errormsg += "Please enter a valid age!<br>";
        }

        // Color validation
        if (color === "" || color === "RGB000") {
            errormsg += "Please select a color!<br>";
            
        }

        console.log("test");

        // Radio button validation
        if (red.checked) {
            choice = red.value;
        } else if (blue.checked) {
            choice = blue.value;
        } else if (green.checked) {
            choice = green.value;
        } else {
            errormsg += "Please select a choice color!<br>";
        }

        // If there are validation errors, show them
        if (errormsg !== "") {
            usermsg.innerHTML = errormsg;
            usermsg.style.color = "red";
            return;
        }

        // Set the selected color in a cookie to expire in 1 day
        setCookie("selectedColor", color, 1);

        // Create a new SurveyUser object and display the result
        let user = new SurveyUser({
            email: email.value,
            age: age.value,
            color: color,
            choice: choice
        });

        user.sayResult(); // Display results and check the cookie

    } catch (error) {
        usermsg.innerHTML = `An unexpected error occurred: ${error.message}`;
        usermsg.style.color = "red";
    }
});