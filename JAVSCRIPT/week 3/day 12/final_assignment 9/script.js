let intervals = []; 
let speeds = []; 
let barCount = 5; 
let winnerDeclared = false;

let grey_background = document.getElementById('grey_background');
let hidden_info = document.getElementById('hidden_info');
let close_btn = document.getElementById('close_btn');
let winner_message = document.getElementById('winner_message');

function update(index) {
    var bar = document.getElementById("status" + (index + 1));

    
    if (parseInt(bar.offsetWidth) < 500) {
        bar.style.width = (parseInt(bar.offsetWidth) + speeds[index]) + "px";
    } else {
        
        window.clearInterval(intervals[index]);
        intervals[index] = null;

        if (!winnerDeclared) {
            showWinner(index);
            winnerDeclared = true;
        }
    }
}

function showWinner(index) {
    const vehicleNames = ["CAR", "MOTORCYCLE", "TRUCK", "BICYCLE", "TRAIN"];
    winner_message.innerText = "Congratulations! " + vehicleNames[index] + " wins!";
    grey_background.style.display = "block";
    hidden_info.style.display = "block";

    for (let i = 0; i < barCount; i++) {
        if (intervals[i]) {
            window.clearInterval(intervals[i]);
            intervals[i] = null;
        }
    }
}

function trigger(index) {
    var bar = document.getElementById("status" + (index + 1));

    
    if (intervals[index]) {
        return;
    }

    
    if (parseInt(bar.offsetWidth) >= 500) {
        bar.style.width = "0";
        return;
    } else {
        
        intervals[index] = window.setInterval(function() { update(index); }, 100);
    }
}


function triggerAll() {
    wiinerDeclared = false;
    for (let i = 0; i < barCount; i++) {
        speeds[i] = Math.floor(Math.random() * 5) + 1; 
        trigger(i); 
    }
}


function resetAll() {
    
    for (let i = 0; i < barCount; i++) {
        if (intervals[i]) {
            window.clearInterval(intervals[i]);
            intervals[i] = null;
        }
        
        document.getElementById("status" + (i + 1)).style.width = "0";
    }
    grey_background.style.display = "none";
    hidden_info.style.display = "none";

    winnerDeclared = false;
}

close_btn.addEventListener("click", function() {
    grey_background.style.display = "none";
    hidden_info.style.display = "none";
})