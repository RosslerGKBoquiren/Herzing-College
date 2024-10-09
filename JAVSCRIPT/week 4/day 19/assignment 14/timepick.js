// Wait for the HTML content to be fully loaded before executing the provided function
document.addEventListener("DOMContentLoaded", function() {
    // Call the setTimePicks function when the DOM content is fully loaded
	//Call the setTimePicks function with parameters "timepick" (class name) and "60mins" (interval)
    setTimePicks("timepick", "60mins");

    window.addEventListener('click', function(event) {
        let isTimePicked = event.target.classList.contains('timepick');
        let isTimeButton = event.target.classList.contains('timebutton');

        if(!isTimePicked && !isTimeButton) {
            hideTimesBoxes();
        }
    });
});

function hideTimesBoxes() {
    let timeslist = document.querySelectorAll('.timeslist');
    timeslist.forEach(function(timeslist) {
        timeslist.style.display = 'none';
    })
}

// Function to dynamically set time pickers
function setTimePicks(classname, interval) {
    // Select all elements with the given class name
	var elems = document.querySelectorAll('.' + classname);
    // Loop through each selected element
    for (var i = 0; i < elems.length; i++) {
	// Create a wrapper div for each element
        var wrapper = document.createElement("div");
        wrapper.className = "timewrap";
		// Create a div to contain the time options
        var times = document.createElement("div");
        times.className = "timeslist";
        
        // Insert wrapper and times list before the selected element
        elems[i].parentNode.insertBefore(wrapper, elems[i]);
        wrapper.appendChild(elems[i]);
        wrapper.appendChild(times);    
        
        // Add times to times list if interval is "60mins"
        if (interval == "60mins") {
            var ampm = "AM";
			// Loop through each hour
            for (var c = 0; c < 24; c++) {
                var hour = c % 12 || 12;
				// Create a time button for each hour
                var timebutton = document.createElement("input");
                timebutton.type = "button";
                timebutton.value = hour + ":00 " + ampm;
                timebutton.className = "timebutton";
                times.appendChild(timebutton);
				
                // Add click event listener to each time button
                timebutton.addEventListener("click", function(e) {
                    setTimeClick(this);
                });
                // Switch from AM to PM at noon
                if (c == 11) {
                    ampm = "PM";
                }
            }
        }
    }
}

// Function to set the selected time into the associated text input field
function setTimeClick(elem){
	// Traverse the DOM to find the associated text input field
    children = elem.parentNode.parentNode.childNodes;

    textbox = null;
    for(x = 0; x < children.length; x++){
        var current = children[x];
        if (current.className == "timepick"){
            textbox = current;
            break;
        }
    }
    // Set the value of the text input field to the value of the clicked time button
    textbox.value = elem.value;
	// Hide the parent element of the clicked time button (timeslist)
    elem.parentNode.style.display = "none";
}

// Function to show the time options list
function showTimesBox(){
	// Set the display property of the timeslist to "block" to show it
    document.querySelector('.timeslist').style.display = "block";
}

// Function to hide the time options list
/* function hideTimesBoxes(){
    document.querySelector('.timeslist').style.display = "none";
} */

