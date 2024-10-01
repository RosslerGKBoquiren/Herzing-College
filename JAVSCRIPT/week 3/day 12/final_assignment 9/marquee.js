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
};