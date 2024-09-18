
    const showBtn = document.getElementById('showBtn');
    const contactInfo = document.getElementById('contactinfo');
    const closeBtn = document.getElementById('closeBtn');
    const backgrey = document.getElementById('backgrey');

    function toggleContactInfo() {
        if (contactInfo.style.display === "block") {
            contactInfo.style.display = "none";
            backgrey.style.display = "none";
        } else {
            contactInfo.style.display = "block";
            backgrey.style.display = "block";
        }
    }

    showBtn.addEventListener('click', toggleContactInfo);

    closeBtn.addEventListener('click', toggleContactInfo);