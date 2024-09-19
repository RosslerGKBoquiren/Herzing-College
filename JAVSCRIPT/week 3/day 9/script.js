// Show an alert once the script starts running (after the page has fully loaded)
alert("The page is fully loaded.");

// Your other logic will follow below:
let divs = document.body.getElementsByTagName("div");

for (let i = 0; i < divs.length; i++) {
    var divid = divs[i].id;

    // Use closure to capture current div ID and set onclick event
    (function(divid) {
        divs[i].onclick = function () {
            clicked(divid);
        };
    })(divs[i].id); // Pass current div's ID to closure
}

// Add hover effect to divs with class "class1"
var classDivs = document.body.getElementsByClassName("class1");
for (let i = 0; i < classDivs.length; i++) {
    classDivs[i].onmouseenter = function () {
        this.style.border = "solid 5px black";
    };

    classDivs[i].onmouseleave = function () {
        this.style.border = "";
    };
}

function clicked(element) {
    alert(element + " was clicked.");
}
