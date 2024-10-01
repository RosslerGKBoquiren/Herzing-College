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
    ford: new Truck('Ford F-150', 'pink', 40, 0),
    chevrolet: new Truck('Chevrolet Silverado', 'brown', 45, 0),
    ram: new Truck('Ram 1500', 'indigo', 38, 0),
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
            let carInfo = {
                name: car.name,
                color: car.color,
                speed: car.speed,
                acceleration: car.acceleration,
            };
            selectedVehicles.push(car); 
            setCookie('selectedCar', JSON.stringify(carInfo), 1);
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
            let motorcycleInfo = {
                name: motorcycle.name,
                color: motorcycle.color,
                speed: motorcycle.speed,
                acceleration: motorcycle.acceleration,
            };
            selectedVehicles.push(motorcycle);
            setCookie('selectedMotorcycle', JSON.stringify(motorcycleInfo), 1);
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
            let bicycleInfo = {
                name: bicycle.name,
                color: bicycle.color,
                speed: bicycle.speed,
                acceleration: bicycle.acceleration,
            };
            selectedVehicles.push(bicycle);
            setCookie('selectedBicycle', JSON.stringify(bicycleInfo), 1);
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
            let trainInfo = {
                name: train.name,
                color: train.color,
                speed: train.speed,
                acceleration: train.acceleration,
            };
            selectedVehicles.push(train)
            setCookie('selectedTrain', JSON.stringify(trainInfo), 1);
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

            if (!truck) {
                console.error("Truck model not found for:", selectedTruck);
                return;
            }

            let truckInfo = {
                name: truck.name,
                color: truck.color,
                speed: truck.speed,
                acceleration: truck.acceleration,
            };

            selectedVehicles.push(truck)
            setCookie('selectedTruck', JSON.stringify(truckInfo), 1);
            console.log("Cookie set for truck:", truckInfo);
        } else {
            console.log("No truck selected, cookie not set.");  
        }
    } catch (error) {
        console.error("Error selecting truck:", error);
    }
});


let startBtn = document.getElementById("startBtn");

startBtn.addEventListener("click", function() {

    let interval = null; 
    let speed = 2;

    if (selectedVehicles.length < 2) {
        alert("Please select at least two vehicles to start the race!");
        return;
    }

    document.querySelectorAll("[id^='progressbar']").forEach(bar => {
        bar.style.width = "0"; 
    });

    let selectedProgressBars = []; 

    selectedVehicles.forEach(vehicle => {
        switch (vehicle.type) {
            case 'car':
                document.getElementById("progressbar1").style.backgroundColor = vehicle.color;
                selectedProgressBars.push(document.getElementById("progressbar1"));
                break;
            case 'motorcycle':
                document.getElementById("progressbar2").style.backgroundColor = vehicle.color;
                selectedProgressBars.push(document.getElementById("progressbar2"));
                break;
            case 'truck':
                document.getElementById("progressbar3").style.backgroundColor = vehicle.color;
                selectedProgressBars.push(document.getElementById("progressbar3"));
                break;
            case 'bicycle':
                document.getElementById("progressbar4").style.backgroundColor = vehicle.color;
                selectedProgressBars.push(document.getElementById("progressbar4"));
                break;
            case 'train':
                document.getElementById("progressbar5").style.backgroundColor = vehicle.color;
                selectedProgressBars.push(document.getElementById("progressbar5"));
                break;
        }
    });

    trigger();
    

    function update() {
        selectedProgressBars.forEach(bar => {
            if (parseInt(bar.style.width) < 500) { 
                bar.style.width = (parseInt(bar.style.width) + speed) + "px";
            } else {
                window.clearInterval(interval);
                interval = null; 
            }
        });
    }

    function trigger() {
        if (interval) {
            return; 
        }

        
        interval = window.setInterval(update, 10);
    }
});


// Check for cookies on page load
let carCookie = getCookie('selectedCar');
    if (carCookie) {
        try {
            let carInfo = JSON.parse(carCookie); // Parse the stringified cookie
            console.log("Car info from cookie:", carInfo);
        } catch (error) {
            console.error("Error parsing car cookie:", error);
        }
    } else {
        console.log("No car cookie found.");
}

// Check for motorcycle cookie
let motorcycleCookie = getCookie('selectedMotorcycle');
    if (motorcycleCookie) {
        try {
            let motorcycleInfo = JSON.parse(motorcycleCookie);
            console.log("Motorcycle info from cookie:", motorcycleInfo);
        } catch (error) {
            console.error("Error parsing motorcycle cookie:", error);
        }
    } else {
        console.log("No motorcycle cookie found.");
}

// Check for bicycle cookie
let bicycleCookie = getCookie('selectedBicycle');
    if (bicycleCookie) {
        try {
            let bicycleInfo = JSON.parse(bicycleCookie);
            console.log("Bicycle info from cookie:", bicycleInfo);
        } catch (error) {
            console.error("Error parsing bicycle cookie:", error);
        }
    } else {
        console.log("No bicycle cookie found.");
}

// Check for train cookie
let trainCookie = getCookie('selectedTrain');
    if (trainCookie) {
        try {
            let trainInfo = JSON.parse(trainCookie);
            console.log("Train info from cookie:", trainInfo);
        } catch (error) {
            console.error("Error parsing train cookie:", error);
        }
    } else {
        console.log("No train cookie found.");
}

// Check for truck cookie
let truckCookie = getCookie('selectedTruck');
if (truckCookie) {
    try {
        let truckInfo = JSON.parse(truckCookie);
        console.log("Truck info from cookie:", truckInfo);
    } catch (error) {
        console.error("Error parsing truck cookie:", error);
    }
} else {
    console.log("No truck cookie found.");
}

