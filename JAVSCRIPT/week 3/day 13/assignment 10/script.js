let replaceBtn = document.getElementById('replaceBtn');

replaceBtn.addEventListener('click', function() {

	try {
		let paragraph = document.getElementById('paragraph').value;
		let wordFinder = document.getElementById('wordFinder').value
		let wordReplacement = document.getElementById('wordReplacement').value;

		if (!wordFinder || !wordReplacement) {
			throw new Error("Both find and replacement words must be provided.");
		}

		if (/\d/.test(wordReplacement)) {
			throw new Error("The 'replace with' field cannot contain numbers.")
		}

		if(paragraph.includes(wordFinder)) {
			let updatedParagraph = paragraph.replace(wordFinder, wordReplacement);
			document.getElementById('paragraph').value = updatedParagraph;

			alert(`Replaced '${wordFinder}' with '${wordReplacement}'.`);

		} else {
			alert(`Word '${wordFinder}' not found in the paragraph.`);
		}
	} catch (error) {
		alert("Error: " + error.message);
	}
})