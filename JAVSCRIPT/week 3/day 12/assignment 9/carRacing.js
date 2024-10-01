import Car from './car.js';
import Motorcycle from './motorcycle.js';
import Bicycle from './bicycle.js'; 
import Train from './train.js'; 
import Truck from './truck.js'; 

import { setCookie, getCookie } from './cookie.js';

// Vehicle Models
const carModels = {
    lamborghini: new Car('Lamborghini', 'yellow', 80, 15),
    ferrari: new Car('Ferrari', 'red', 85, 20),
    bugatti: new Car('Bugatti', 'blue', 90, 25),
};

const motorcycleModels = {
    harley: new Motorcycle('Harley Davidson', 'black', 70, 10),
    ducati: new Motorcycle('Ducati', 'red', 75, 12),
    yamaha: new Motorcycle('Yamaha', 'blue', 65, 8),
};

const bicycleModels = {
    trek: new Bicycle('Trek', 'green', 25, 5),
    giant: new Bicycle('Giant', 'orange', 30, 6),
    specialized: new Bicycle('Specialized', 'violet', 28, 7),
};

const trainModels = {
    shinkansen: new Train('Shinkansen', 'white', 50, 25),
    maglev: new Train('Maglev', 'grey', 60, 30),
    tgv: new Train('TGV', 'yellow', 55, 30),
};

const truckModels = {
    ford: new Truck('Ford F-150', 'pink', 40),
    chevrolet: new Truck('Chevrolet Silverado', 'brown', 45),
    ram: new Truck('Ram 1500', 'indigo', 38),
};

// Vehicle Selection Event Listeners
let carSelect = document.getElementById('cars');
let motorcycleSelect = document.getElementById('motorcycles');
let bicycleSelect = document.getElementById('bicycles');
let trainSelect = document.getElementById('trains');
let truckSelect = document.getElementById('trucks');

let selectedVehicles = [];

// Car Selection Event Listener
carSelect.addEventListener('change', function() {
    let selectedCar = this.value;
    try {
        if (selectedCar) {
            let car = carModels[selectedCar]; 
            selectedVehicles.push(car); 
            setCookie('selectedCar', JSON.stringify(car), 1);
            console.log("Cookie set for car:", car);
             
        }
    } catch (error) {
        console.error("Error selecting car:", error);
    }
});

// Motorcycle Selection Event Listener
motorcycleSelect.addEventListener('change', function() {
    let selectedMotorcycle = this.value;
    try {
        if (selectedMotorcycle) {
            let motorcycle = motorcycleModels[selectedMotorcycle];
            selectedVehicles.push(motorcycle);
            setCookie('selectedMotorcycle', JSON.stringify(motorcycle), 1);
            console.log("Cookie set for motorcycle:", motorcycle);
            
        }
    } catch (error) {
        console.error("Error selecting motorcycle:", error);
    }
});

// Bicycle Selection Event Listener
bicycleSelect.addEventListener('change', function() {
    let selectedBicycle = this.value;
    try {
        if (selectedBicycle) {
            let bicycle = bicycleModels[selectedBicycle];
            selectedVehicles.push(bicycle);
            setCookie('selectedBicycle', JSON.stringify(bicycle), 1);
            console.log("Cookie set for bicycle:", bicycle);
        
        }
    } catch (error) {
        console.error("Error selecting bicycle:", error);
    }
});

// Train Selection Event Listener
trainSelect.addEventListener('change', function() {
    let selectedTrain = this.value;
    try {
        if (selectedTrain) {
            let train = trainModels[selectedTrain];
            selectedVehicles.push(train)
            setCookie('selectedTrain', JSON.stringify(train), 1);
            console.log("Cookie set for train:", train);
            
            
        }
    } catch (error) {
        console.error("Error selecting train:", error);
    }
});

// Truck Selection Event Listener
truckSelect.addEventListener('change', function() {
    let selectedTruck = this.value;
    try {
        if (selectedTruck) {
            let truck = truckModels[selectedTruck];
            selectedVehicles.push(truck);
            setCookie('selectedTruck', JSON.stringify(truck), 1);
            console.log("Cookie set for truck:", truck);
            
            
        }
    } catch (error) {
        console.error("Error selecting truck:", error);
    }
});


let startBtn = document.getElementById("startBtn");

// Start Race Function
startBtn.addEventListener("click", function() {
    console.log("Start Race function called."); 

    // Check if at least two vehicles are selected
    if (selectedVehicles.length < 2) {
        alert("Please select at least two vehicles to start the race!");
        return;
    }

    // Reset all progress bars before starting the race
    document.querySelectorAll("[id^='progressbar']").forEach(bar => {
        bar.style.width = "0"; // Reset width to 0 for all progress bars
    });

    // Start the progress bar animations for each selected vehicle
    selectedVehicles.forEach((vehicle, index) => {
        let bar = document.getElementById(`progressbar${index + 1}`); // Get the corresponding progress bar
        bar.style.backgroundColor = vehicle.color; // Set the color of the progress bar
    });

    // Call the trigger function to start the animation
    trigger(); 
});


// Update Function
function update() {
    console.log("Update function called."); // Debugging
    let raceFinished = false;

    // Update each selected vehicle's progress bar
    selectedVehicles.forEach((vehicle, index) => {
        let bar = document.getElementById(`progressbar${index + 1}`); // Access the corresponding progress bar
        let speed = vehicle.move(); // Call the move() method to get updated speed

        // Use the vehicle's speed to calculate how much to increment the progress bar
        let increment = speed / 100; // Adjust this divisor to control the speed of the progress bar

        // Update the width of the progress bar
        if (parseInt(bar.offsetWidth) < 2000) {
            bar.style.width = (parseInt(bar.offsetWidth) + increment) + "px"; // Increment the bar width
        } else {
            raceFinished = true; // Vehicle has finished the race
            window.clearInterval(interval);
            alert(`CONGRATULATIONS! ${vehicle.name} has won the race!`); // Alert the winner
            interval = null; // Reset the interval
        }
    });

    // Disable the start button if the race is finished
    if (raceFinished) {
        document.getElementById("startBtn").disabled = true; 
    }
}

// Trigger Function
function trigger() {
    if (interval) return; // Prevent starting a new interval if one is already running
    interval = window.setInterval(update, 100); // Call update every 100 milliseconds
}

// Reset Button Functionality
document.getElementById("resetBtn").addEventListener("click", function() {
    // Reset progress bars
    document.querySelectorAll("[id^='progressbar']").forEach(bar => {
        bar.style.width = "0"; // Reset width
        bar.style.backgroundColor = ""; // Reset background color
    });

    // Clear selected vehicles array
    selectedVehicles = [];
    
    // Reset dropdowns to default
    document.querySelectorAll("select").forEach(select => {
        select.selectedIndex = 0; // Reset to the first option (default)
    });
    
    console.log("Race reset. All selections cleared.");
});




// Check for cookies on page load
let carCookie = getCookie('selectedCar');
    if (carCookie) {
        let carInfo = JSON.parse(carCookie); // Parse the stringified cookie
        console.log("Car info from cookie:", carInfo);
    } else {
        console.log("No car cookie found.");
}

// Check for motorcycle cookie
let motorcycleCookie = getCookie('selectedMotorcycle');
    if (motorcycleCookie) {
        let motorcycleInfo = JSON.parse(motorcycleCookie);
        console.log("Motorcycle info from cookie:", motorcycleInfo);
    } else {
        console.log("No motorcycle cookie found.");
}

// Check for bicycle cookie
let bicycleCookie = getCookie('selectedBicycle');
    if (bicycleCookie) {
        let bicycleInfo = JSON.parse(bicycleCookie);
        console.log("Bicycle info from cookie:", bicycleInfo);
    } else {
        console.log("No Bicycle Cookie found");
}

// Check for train cookie
let trainCookie = getCookie('selectedTrain');
    if (trainCookie) {
        let trainInfo = JSON.parse(trainCookie);
        console.log("Train info from cookie:", trainInfo);
    } else {
        console.log("No train Cookie found");
}

// Check for truck cookie
let truckCookie = getCookie('selectedTruck');
    if (truckCookie) {
        let truckInfo = JSON.parse(truckCookie);
        console.log("Truck info from cookie:", truckInfo);
    } else {
        console.log("No Truck Cookie found");
};
