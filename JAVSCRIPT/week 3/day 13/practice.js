// regex classes

let strToMatch = "a bat, a Cat, a fAt baT, a faT cat";
let reBatCatFat = /[bcf]at/gi;
let arrMatches = strToMatch.match(reBatCatFat);

console.log(arrMatches);
// output: ["bat", "Cat", "fAt", "baT", "faT", "cat"];



// Negation class
let strToMatch = "a bat, a Cat, a fAt batl a faT cat";
let reNegation = /[^bc]at/gi; 
// g represents global search - looking for entire strings
// i represents case-insensitive search - to ignore the case of letters while matching
let arrMatches = strToMatch.match(reNegation);

console.log(arrMatches);

// output: ["fAt", "faT"]



// Regex in javascript
let strToMatch = "a bat, a Cat, a fAt baT, a faT cat";
let reAt = /at/;

// using exec() to find the first occurence of a pattern
let arrMatches = reAt.exec(strToMatch);
// [0] represents the first match found since 0, means index 0 or first
console.log(arrMatches[0]);
// output: "at" (from "bat")


// using replace() with a regex pattern
let strToMatch = "The sky is red";
let reRed = /red/;
let sResultText = sToChange.replace(reRed, "blue");

console.log(sResultText); // output: "The sky is blue"



// using split() with regex
// splitting a string with a comma

let sColor = "red,blue,yellow,green";
let arrColors = sColor.split(",");

console.log(arrColors); 
// output: ["red", "blue", "yellow", "green"];

// splitting a string using regex to match a comma
let sColor = "red,blue,yellow,green";
let reComma = /\,/;
let arrColors = sColor.split(reComma);

console.log(arrColors); 
// output: ["red", "blue", "yellow", "green"]


// removing newline characters
let sStringWithNewLines = "Hello\nWorld\nHow\nare\nyou?";
let sNewString = sStringWithNewLines.replace(/\n/g, "");

console.log(sNewString);
// output: "HelloWorldHowareyou?"