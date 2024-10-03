
let textArea = document.getElementById("textArea");

textArea.addEventListener('keyup', function() {
    limitText(this, document.getElementById("textBox"), 100);
    
    
});

function limitText(limitField, limitCount, limitNum) {
    if (limitField.value.length > limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);
    }

    let charRemaining = limitNum - limitField.value.length;

    limitCount.value = `You have ${charRemaining} characters left.`;
}
