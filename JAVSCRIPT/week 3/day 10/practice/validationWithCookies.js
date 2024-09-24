
// prompt the user to enter their name
function enterName() {
    let name;

    try {
        name = prompt("Please enter your name: ", "User");

        if(name == null || name.trim() === "") throw "Name cannot be empty.";

        if(!/^[a-zA-Z]+$/.test(name)) throw "Name must contain only letters."

        if(name.length < 3) throw "Name is too short.";

        setCookie("username", name, 1);

        document.getElementById("output").innerHTML = `Hello ${name}! Your name has been saved in a cookie.`;
    } catch (err) {
        alert(`Error: ${err}`);
    }
}

// function to set a cookie
function setCookie(cname, cvalue, exdays) {
    let d = new Date();
    d.setTime(d.getTime() + (exdays * 24 * 60 * 60 * 1000));
    let expires = `expires = ${d.toUTCString()}`;

    document.cookie = `${cname}=${cvalue}; ${expires}; path=/`;
}

// function to get a cookie value
function getCookie(cname) {
    let name = `${cname}=`;
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(";");
    for(let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === " ") {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }

    }
    return "";
}

// on page load, check if the uer has a saved name in the cookie
function checkCookie() {
    let username = getCookie("username");
    if (username != "") {
        document.getElementById("output").innerHTML = `Welcome back, ${username}!`;    
    }
}