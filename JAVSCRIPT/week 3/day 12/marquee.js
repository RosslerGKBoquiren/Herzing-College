
window.onload = function () {
    var msg = "Javascript animations are based on recursive functions. These are alot like loops. A recursive function calls itself until a specific condition is met (otherwise it runs forever).";
    var length = 50; //The total width of the scrolling marquee in characters
    var position = 0; //the current position in the msg
    var padding = msg.replace(/./g, " ").substr(0, length);
    var finalMsg = padding + msg;

    function updateText() {
        var curMsg = finalMsg.substr(position++, length);
        document.getElementById("marquee").innerHTML = curMsg;
        if (position == finalMsg.length) {
            position = 0;
        }

        setTimeout(updateText, 100);
    }

    setTimeout(updateText, 100);
}
/* msg.replace(/./g, " "): 
This part of the code uses the replace method with a regular expression /./g 
to replace each character in the message (msg) with a space. 
Here, the . in the regular expression matches any character. 
The g flag stands for global, meaning it replaces all occurrences of the matched characters. 
So, it effectively replaces every character in the message with a space. */
/*This string now consists of spaces with the same length as the original message.

.substr(0, length): This part of the code extracts a substring from the padded string created in the previous step, 
starting from index 0 and ending at the specified length. 
In our case, the specified length is 50.
So, it extracts the substring from index 0 to index 49 (since JavaScript substrings are zero-based), 
resulting in the first 50 characters of the padded string.*/



// based on <div id="marquee"> function calls itself until a specific condition </div>