

let textArea = document.getElementById("textArea");
let textBox = document.getElementById("textBox");

textArea.addEventListener('keyup', function() {
    limitText(textArea, textBox, 25);   
});

function limitText(limitField, limitCount, limitNum) {
    
    let currentLength = limitField.value.length;

    if (currentLength >= limitNum) {
        limitField.value = limitField.value.substring(0, limitNum);  
        // limitField.disabled = true;  
    }

    let remainingChars = limitNum - limitField.value.length
    limitCount.value = `You have _${remainingChars}_ characters left.`;


    if (remainingChars > 17) {
        document.body.style.backgroundColor = "#009473";  
    } else if (remainingChars <= 17 && remainingChars > 9) {
        document.body.style.backgroundColor = "#FEDD00";  
    } else if (remainingChars <= 9 && remainingChars > 5) {
        document.body.style.backgroundColor = "#FF6A13";  
    } else if (remainingChars <= 5) {
        document.body.style.backgroundColor = "#D50032";  
    }
}
