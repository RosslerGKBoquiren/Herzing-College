window.addEventListener('DOMContentLoaded', function() {
    let slideIndex = 0;
    showSlides();

    function showSlides() {
        let slides = document.getElementsByClassName('slide');
        
        
        for (let i = 0; i < slides.length; i++) {
            slides[i].style.left = '100%';  
        }

        
        slideIndex++;
        if (slideIndex > slides.length) {
            slideIndex = 1;
        }

        
        slides[slideIndex - 1].style.left = '0';

        
        changeBodyColor(slides[slideIndex - 1].id);

        
        setTimeout(showSlides, 3000);
    }

    
    function changeBodyColor(slideId) {
        switch (slideId) {
            case 'red':
                document.body.style.backgroundColor = 'lightcoral';
                break;
            case 'blue':
                document.body.style.backgroundColor = 'lightblue';
                break;
            case 'green':
                document.body.style.backgroundColor = 'lightgreen';
                break;
            case 'yellow':
                document.body.style.backgroundColor = 'lightgoldenrodyellow';
                break;
            default:
                document.body.style.backgroundColor = 'white';  
        }
    }
});
