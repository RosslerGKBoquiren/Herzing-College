for (let i = 1; i <= 3; i++) {
    const button = document.createElement('button');
    button.innerHTML = 'Button ' + i;
    document.body.appendChild(button);

    // Add click event listener with delay using closure
    (function(buttonNumber) {
        button.addEventListener('click', function() {
            setTimeout(function() {
                alert('You clicked Button ' + buttonNumber);
            }, 2000); // 2-second delay
        });
    })(i); // Passing i to the closure
}
