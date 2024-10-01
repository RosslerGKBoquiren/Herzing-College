
// function to set a cookie
export function setCookie(name, value, days) {
    let date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
    let expires = "expires=" + date.toUTCString();
    document.cookie = `${name}=${value}; ${expires}; path=/`;
}

// function to get a cookie by name
export function getCookie(name) {
    let nameWithEquals = `${name}=`;
    let cookieArray = document.cookie.split(';');
    for (let cookie of cookieArray) {
        while (cookie.charAt(0) === ' ') cookie = cookie.substring(1); // Trim leading spaces
        if (cookie.indexOf(nameWithEquals) === 0) {
            return cookie.substring(nameWithEquals.length, cookie.length); // Return cookie value
        }
    }
    return null; // Return null if cookie not found
}
