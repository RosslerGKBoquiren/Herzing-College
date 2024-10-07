

window.addEventListener('DOMContentLoaded', function() {
    let sliderContainer = document.getElementById('sliderContainer');
    let totalSlides = document.querySelectorAll('.slide').length;
    let currentSlide = 0;
    
    function getSlideWidth() {
        return document.getElementById('slider').offsetWidth;
    } 

    sliderContainer.style.width = `${totalSlides * 100}%`;

    function nextSlide() {
        currentSlide++;
        if (currentSlide === totalSlides) {
            currentSlide = 0;
        }

        sliderContainer.style.marginLeft = `-${currentSlide * getSlideWidth()}px`;
    }

    setInterval(nextSlide, 3000);

    window.addEventListener('resize', function() {
        sliderContainer.style.marginLeft = `-${currentSlide * getSlideWidth()}px`;
    })
});