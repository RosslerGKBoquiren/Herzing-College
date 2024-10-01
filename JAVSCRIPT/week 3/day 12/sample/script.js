var intervals = []; // Array to hold intervals for each bar
var speeds = []; // Array to hold random speeds for each bar
var barCount = 5; // Number of progress bars

// Function to update each bar's width
function update(index) {
    var bar = document.getElementById("status" + (index + 1));

    // Check if the bar's width has reached 500 pixels
    if (parseInt(bar.offsetWidth) < 500) {
        bar.style.width = (parseInt(bar.offsetWidth) + speeds[index]) + "px";
    } else {
        // Clear the interval for the completed bar
        window.clearInterval(intervals[index]);
        intervals[index] = null;
    }
}

// Trigger the progress animation for each individual bar
function trigger(index) {
    var bar = document.getElementById("status" + (index + 1));

    // If the interval is already set for this bar, don't run it again
    if (intervals[index]) {
        return;
    }

    // Clear the bar to start over when it's full
    if (parseInt(bar.offsetWidth) >= 500) {
        bar.style.width = "0";
        return;
    } else {
        // Start the animation with a random speed for this specific bar
        intervals[index] = window.setInterval(function() { update(index); }, 100);
    }
}

// Trigger progress for all bars simultaneously
function triggerAll() {
    // Generate random speeds for each bar
    for (let i = 0; i < barCount; i++) {
        speeds[i] = Math.floor(Math.random() * 5) + 1; // Random speed between 1 and 5 pixels
        trigger(i); // Start the progress for each bar
    }
}

// Function to reset all progress bars
function resetAll() {
    // Clear all intervals to stop current animations
    for (let i = 0; i < barCount; i++) {
        if (intervals[i]) {
            window.clearInterval(intervals[i]);
            intervals[i] = null;
        }
        // Reset the width of each progress bar
        document.getElementById("status" + (i + 1)).style.width = "0";
    }
}