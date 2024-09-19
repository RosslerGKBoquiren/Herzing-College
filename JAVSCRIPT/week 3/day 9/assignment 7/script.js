
let click = document.getElementById('click');

click.addEventListener('click', function() {
    click.style.backgroundColor = getRandomColor();
});

function getRandomColor() {
    const randomNumber = Math.floor(Math.random() * 10) + 1;

    switch(randomNumber) {
        case 1:
            return "black";
        case 2:
            return "white";
        case 3:
            return "blue";
        case 4:
            return "green";
        case 5:
            return "yellow";
        case 6:
            return "orange";
        case 7:
            return "red";
        case 8:
            return "violet";
        case 9:
            return "pink";
        case 10:
            return "grey";
        default:
            return "black";
    }
}