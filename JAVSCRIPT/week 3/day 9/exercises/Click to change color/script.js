

// create and append div elements
for (let i = 1; i <= 3; i++) {
    let div = document.createElement('div');
    div.id = 'div' + 1;
    div.style.width = '100px';
    div.style.height = '100px';
    div.style.border = '1px solid black';
    document.body.appendChild(div);

    // add click even listener using a closure
    (function(div) {
        div.addEventListener('click', function () {
            div.style.backgroundColor = getRandomColor();
        });
    })(div);
}

function getRandomColor() {
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}