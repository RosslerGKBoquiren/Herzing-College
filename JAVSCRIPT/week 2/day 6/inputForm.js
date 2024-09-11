// write a function that will validate all fields when the submit button is clicked.
// username
// name
// password
// confirm password
// email
// province
// accept terms checkbox
// submit button
// passwords must match
// default value for province
// output results

let submit_btn = document.getElementById("submit_btn");

submit_btn.addEventListener("click", function(event) {
    event.preventDefault();

    let submit_btn = document.getElementById("submit_btn");
    let username = document.getElementById("username").value;
    let name = document.getElementById("name").value;
    let password = document.getElementById("password").value;
    let confirm_password = document.getElementById("confirm_password").value;
    let email = document.getElementById("email").value;
    let province = document.getElementById("province").value;
    let accept_terms_checkbox = document.getElementById("accept_terms_checkbox");
    let output_results = document.getElementById("output_results");
    let user_object = {};

    output_results.innerHTML = "";

    // min length 3 chars, max length 15 chars, only alphanumeric chars and underscores
    let username_regex = /^[a-zA-Z0-9](?!.*__)[a-zA-Z0-9_]{1,13}[a-zA-Z0-9]$/;
    // only letters, spaces, hyphens, and apostrophes, min length 2 chars
    let name_regex =  /^[A-Za-z]+([ '-][A-Za-z]+)*$/;
    // 8 characters, 1 uppercase, 1 lowercase, 1 digit, 1 special character
    let password_regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    // domain min 2 chars, letters, digits, dots, hyphens, underscores, percentage, plus signs
    let email_regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

    let valid = true;
    
    // Validate Username
    if (username === "") {
        output_results.innerHTML += "Username cannot be empty. ";
        valid = false;
    } else if (!username_regex.test(username)) {
        output_results.innerHTML += "Username must be between 3-15 characters and can only contain alphanumeric characters and underscores. ";
        valid = false;
    }

    // Validate Name
    if (name === "") {
        output_results.innerHTML += "Name cannot be empty. ";
        valid = false;
    } else if (!name_regex.test(name)) {
        output_results.innerHTML += "Please enter a valid name (only letters, spaces, hyphens, and apostrophes). ";
        valid = false;
    }

    // Validate Password
    if (password === "") {
        output_results.innerHTML += "Password cannot be empty. ";
        valid = false;
    } else if (!password_regex.test(password)) {
        output_results.innerHTML += "Password must be at least 8 characters long, with at least one uppercase letter, one lowercase letter, one number, and one special character. ";
        valid = false;
    }

    // Validate Confirm Password
    if (confirm_password === "") {
        output_results.innerHTML += "Please confirm password. ";
        valid = false;
    } else if (confirm_password !== password) {
        output_results.innerHTML += "Passwords do not match. ";
        valid = false;
    }

    // Validate Email
    if (email === "") {
        output_results.innerHTML += "Email cannot be empty. ";
        valid = false;
    } else if (!email_regex.test(email)) {
        output_results.innerHTML += "Please enter a valid email address. ";
        valid = false;
    }

    // Validate Province
    if (province === "") {
        output_results.innerHTML += "Please select a province. ";
        valid = false;
    }

    // Validate Terms Acceptance
    if (!accept_terms_checkbox.checked) {
        output_results.innerHTML += "Please confirm the Terms and Conditions. ";
        valid = false;
    }

    // If everything is valid, create the user object
    if (valid) {
        user_object = {
            Username: username,
            Name: name,
            Password: password,
            Email: email,
            Province: province
        };

        output_results.innerHTML += `Information verified! Name: ${user_object.Name}, Username: ${user_object.Username}, Email: ${user_object.Email}, Province: ${user_object.Province}.`;
    }

});