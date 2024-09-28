 
    function update() {
        //Select the status bar
        var div = document.getElementById("status");

        //Check to see if full width was reached
		
		//offsetWidth is a property in JavaScript that returns the width of an element, 
		//including its padding, border, and optionally scrollbar width, but not its margin. 
		//It gives the total width of the element on the page.
        if (parseInt(div.offsetWidth) < 500) {
            div.style.width = (parseInt(div.offsetWidth) + 5) + "px";
			//alert(div.offsetWidth);
            setTimeout(update, 100);
        }
    }

    window.onload = function () {
        var div = document.getElementById("status");
       //alert(div.offsetWidth);
    }
