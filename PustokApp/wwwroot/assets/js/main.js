﻿$(document).ready(function () {
    $('.bookModal').click(function (e) {
        e.preventDefault();
        let url = $(this).attr('href');
        fetch(url)
            .then(response => response.text())
            .then(data => {
                $('#quickModal .modal-dialog').html(data);
                const firstSlider =
                {
                    "slidesToShow": 1,
                    "arrows": false,
                    "fade": true,
                    "draggable": false,
                    "swipe": false,
                    "asNavFor": ".product-slider-nav"
                }
                const secondSlider = {
                    "infinite": true,
                    "autoplay": true,
                    "autoplaySpeed": 8000,
                    "slidesToShow": 4,
                    "arrows": true,
                    "prevArrow": { "buttonClass": "slick-prev", "iconClass": "fa fa-chevron-left" },
                    "nextArrow": { "buttonClass": "slick-next", "iconClass": "fa fa-chevron-right" },
                    "asNavFor": ".product-details-slider",
                    "focusOnSelect": true
                }
                $('.product-details-slider').slick(firstSlider);
                $('.product-slider-nav').slick(secondSlider);

            });
            $('#quickModal').modal('show');
    })
});