


import Car from './car.js';

// header MARQUEE
window.onload = function() {
    let msg = "PLACE YOUR BETS, AND LET'S START THE RACE! THE FIRST VEHICLE TO REACH THE FINISH LINE, WINS!";
    
    let length = 60; // total width of the scrolling marquee in characters
    let position = 0; // current position in the msg
    let padding = msg.replace(/./g, " ").substring(0, length); // padding for the start of the message
    let finalMsg = padding + msg; // final message with initial padding

    function marqueeText() {
        // Get current substring from position to position + length
        let curMsg = finalMsg.substring(position, position + length);
        document.getElementById("marquee").innerHTML = curMsg; // display the message

        position++; // move to the next position
        if (position == finalMsg.length) {
            position = 0; // reset position to create a loop effect
        }

        setTimeout(marqueeText, 100); // call marqueeText every 100 milliseconds
    }

    marqueeText(); // Start the marquee animation

    // vehicle PROPERTIES

    let carSelect = document.getElementById('cars');

    const carModels = {
        lamborghini: new Car('Lamborghini', 'yellow', 200, 15),
        ferrari: new Car('Ferrari', 'red', 220, 20),
        bugatti: new Car('Bugatti', 'blue', 240, 25),
    };

    function setCookie(name, value, days) {
        let date = new Date();
        date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
        let expires = "expires=" + date.toUTCString();
        document.cookie = name + "=" + value + ";" + expires + ";path=/"; 
    }

    function getCookie(name) {
        let nameWithEquals = name + "=";
        let cookieArray = document.cookie.split(';');
        for (let i = 0; i < cookieArray.length; i++) {
            let cookie = cookieArray[i];
            while (cookie.charAt(0) === ' ') cookie = cookie.substring(1, cookie.length);
            if (cookie.indexOf(nameWithEquals) === 0) return cookie.substring(nameWithEquals.length, cookie.length);
        }
        return null; // Return null if cookie not found
    }


    console.log('carRacing.js is loaded successfully');

    carSelect.addEventListener('change', function() {
        let selectedCar = this.value;
        try {
            if (selectedCar) {
                let car = carModels[selectedCar];

                let carInfo = {
                    name: car.name,
                    color: car.color,
                    speed: car.speed,
                    acceleration: car.acceleration,
                };

                // Set cookie with stringified object
                setCookie('selectedCar', JSON.stringify(carInfo), 1);
            }

        } catch (error) {
            console.error("Error selecting car:", error); // Changed alert to console.error
        }
    });

    // Check for the cookie on page load
    let carCookie = getCookie('selectedCar');
    if (carCookie) {
        let carInfo = JSON.parse(carCookie); // Parse the stringified cookie
        console.log("Car info from cookie:", carInfo);
    }
};
