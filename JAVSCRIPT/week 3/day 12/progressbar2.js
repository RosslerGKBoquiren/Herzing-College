

var interval = null;// used to keep track of the interval
var speed = 2; //the speed in pixels we want the animation to move in.

function update() {
    //Select the status bar
    var bar = document.getElementById("status");

    //Check to see if full width was reached (500 pixels)
    //offset width will give us a numeric width property.
    //We can use this for comparison to the full width we are animating to.
    if (parseInt(bar.offsetWidth) < 500) {
        bar.style.width = (parseInt(bar.offsetWidth) + speed) + "px";
    } else {
        //clear the interval
        //this will destroy the interval id and everything associated with it,
        //but this is ok, its just a way of managing all the objects that are animating.
        window.clearInterval(interval);
        interval = null;
    }
    //console.log(typeof bar.offsetWidth);
}

window.onload = function () {
    var bar = document.getElementById("status");
    //alert(div.offsetWidth);
}

//We use this trigger function to set the animation in motion, and manage the interval variable.
//The interval variable sets a unique id for that particular animation within the context of the browser.
//If we wanted to use multiple animations we would need to set more than one interval variable and keep 
//track of it based on an trigger function such as this one.
function trigger() {
    var bar = document.getElementById("status");        

    //if the interval is defined by the animation, then we want to stop another animation from occuring.
    //testing a variable that is not a boolean in an if statement will check to see if it is null or 
    //if there is an object for it to access. If the object is null, the result will be false, 
    //and if it is defined then it will be true.
    if (interval) {
        return;
    }

    //clear the bar to start over when its full
    //his function returns early to prevent starting another animation.
    if (parseInt(bar.offsetWidth) >= 500) {
        bar.style.width = "0";
        return;
    } else {
    //If the width is less than 500 pixels, 
    //indicating that the animation is not running and the status bar is not full, the animation is started by 
    //setting up an interval that calls the update() function every 10 milliseconds (window.setInterval("update()", 10))
        interval = window.setInterval("update()", 10);
    }
    
}

