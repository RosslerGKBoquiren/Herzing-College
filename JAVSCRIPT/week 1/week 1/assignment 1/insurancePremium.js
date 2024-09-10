

// Create a program that calculates the total cost of an automobile insurance premium 
// based the drivers age and number of accidents they have had
// the insurance charge will start at $500
// if the driver is under 25 years old, there will be an additional surchage of $100
// there will be additional surcharge for accidents which will depend on the number of accidents had
/*
1 - 2 accidents: $25 surcharge
3 - 4 accidents: $75 surcharge
5 accidents: $100 surchage
6 < no insurance
*/

// to calculate the total cost of the insurance premium, the program will ask the user for their age
// and the number of accidents they have had
// the program will then applu the appropriate surcharges and calculate the total cost of the premium

const nameInput = document.getElementById("nameInput");
const ageInput = document.getElementById("ageInput");
const accidentsInput = document.getElementById("accidentsInput");
const submitBtn = document.getElementById("submitBtn");
const output = document.getElementById("output");

submitBtn.addEventListener("click", function() {

    // get input values
    const name = nameInput.value;
    const age = parseInt(ageInput.value);
    const accidents = parseInt(accidentsInput.value);

    // Regex for name validation
    const nameRegex = /^[A-Za-z\s]+$/;

    // check if the name matches the regex
    if(!nameRegex.test(name)) {
        output.textContent = "Please enter a valid name (letters and spaces only)."
        return;
    }

    // check if age is valid between 1 and 100
    if (isNaN(age) || age < 1 || age > 100) {
        output.textContent = "Please enter a valid age.";
        return;
    }

    // check if number of accident is valid
    if(accidents < 0 || isNaN(accidents)) {
        output.textContent = "Please enter a valid number of accidents";
        return;
    }


    // calculate insurance premiums
    let insuranceCharge = 500;
    let additionalCharge = 100;
    let surcharge = 0;

    switch(accidents) {
        case 0:
            surcharge = 0;
            break;
        case 1:
        case 2: 
            surcharge += 25;
            break;
        case 3:
        case 4: 
            surcharge += 75;
            break;
        case 5: 
            surcharge += 100;
            break;
        default:
            if (accidents > 5) {
            output.textContent = `Hey ${name}, as of this time, we cannot provide you with a quote due to your number of accidents.`;
            return;
            }
    }
    
    if( age < 18) { // check all ages under 18
        output.textContent = `Hey ${name}, you are too young to drive. I can't give you a quote.`;
    } else if (age >= 18 && age < 25) { // ages between 18 and under 25
        let totalPremium = insuranceCharge + additionalCharge + surcharge;
        output.textContent = `Hi ${name}, your annual insurance premiums are $${totalPremium}`;
    } else if (age >= 25) { // ages equal and above 25
        let totalPremium = insuranceCharge + surcharge;
        output.textContent = `Hi ${name}, your annual insurance premiums are $${totalPremium}`;
    } else {
        output.textContent = `I could not provide a quote at this time. Please try again.`;
    }

});