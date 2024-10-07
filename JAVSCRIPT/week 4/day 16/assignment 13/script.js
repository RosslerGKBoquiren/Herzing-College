window.addEventListener('DOMContentLoaded', function() {
    const sliderContainer = document.getElementById('sliderContainer');
    const slides = document.querySelectorAll('.slide');
    const totalSlides = slides.length;
    let currentSlide = 0;

    
    sliderContainer.style.marginLeft = '0px';

    
    function getSlideWidth() {
        return document.getElementById('slider').offsetWidth;
    }

    function nextSlide() {
        currentSlide++;

        
        if (currentSlide === totalSlides) {
            currentSlide = 0;
        }

        
        sliderContainer.style.marginLeft = `-${currentSlide * getSlideWidth()}px`;

        changeBodyColor(slides[currentSlide].id);
    }

    // Automatically change slides every 3 seconds
    setInterval(nextSlide, 3000);

    // Adjust the slide width and reapply the margin on window resize
    window.addEventListener('resize', function() {
        const slideWidth = getSlideWidth();  
        sliderContainer.style.marginLeft = `-${currentSlide * slideWidth}px`;  
    });


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
