const vegetables = ['carrot', 'celery', 'spinach', 'lettuce', 'brocolli'];

// Loop over the array and create a button for each item
for (let i = 0; i <vegetables.length; i++) {
    let button = document.createElement('button');
    button.innerHTML = vegetables[i];
    document.body.appendChild(button);

    // add click event using closure to capture the index
    // functions are wrapped in IIFE Immediately Invoked Function Expression
    (function(index) {
        button.addEventListener('click', function() {
            alert('You clicked vegetable at index ' + index);
        });
    })(i);
}