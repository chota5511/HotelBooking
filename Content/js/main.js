(function ($) {
	"use strict";

    jQuery(document).ready(function($){

        /* happy-clients-carousel Start*/
        $(".happy-clients-carousel").owlCarousel({
            items: 3,
            loop: true,
            dots: true,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            margin: 30,
            dotsData: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false,
                         loop:true
                    },
                    450:{
                        items:1,
                        nav:false,
                         loop:true
                    },
                    600:{
                        items:2,
                        nav:false,
                         loop:true
                    },
                    1000:{
                        items:3,
                        nav:true,
                        loop:true
                    }
                }
            
            
        });
        /* happy-clients-carousel end*/
        /* Counter Up Start*/
        $('.counter').counterUp();
        /* Counter Up end*/
        /* tours-details-gallery Start*/
        $(".tours-details-gallery").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: true,
            navText: ['<i class="zmdi zmdi-chevron-left"></i>', '<i class="zmdi zmdi-chevron-right"></i>'],
            autoplay: true,
            dotsData: true
        });
        /* tours-details-gallery end*/
        /* shop-details-gallery Start*/
        $(".shop-details-gallery").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: false,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            dotsData: true
        });
        /* shop-details-gallery end*/
        /* destination-honeymoon-carousel Start*/
        $(".destination-honeymoon-carousel").owlCarousel({
            items: 3,
            loop: true,
            dots: true,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:false
                    },
                    1000:{
                        items:3
                    }
                }
            
            
        });
        /* destination-honeymoon-carousel end*/
        /* hp2-testimonial-carousel Start*/
        $(".hp2-testimonial-carousel").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:1,
                        nav:true
                    },
                    1000:{
                        items:1
                    }
                }
            
            
        });
        /* hp2-testimonial-carousel end*/
        /* holiday-packages-right-carousel Start*/
        $(".holiday-packages-right-carousel").owlCarousel({
            items: 2,
            loop: true,
            dots: true,
            nav: false,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:false
                    },
                    1000:{
                        items:2,
                        nav:false,
                        loop:false
                    }
                }
            
            
        });
        /* holiday-packages-right-carousel end*/
        /* best-tour-packages-carousel-hp3 carousel Start*/
        $(".best-tour-packages-carousel-hp3").owlCarousel({
            items: 3,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:false
                    },
                    1000:{
                        items:3,
                        autoplay:true
                    }
                }
            
            
        });
        /* best-tour-packages-carousel-hp3 carousel end*/
        /* hp3-testimonial-carousel Start*/
        $(".hp3-testimonial-carousel").owlCarousel({
            items: 3,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:1,
                        nav:false
                    },
                    1000:{
                        items:3,
                        autoplay:true
                    }
                }
            
            
        });
        /* hp3-testimonial-carousel end*/
        /* popular-destinations-hp3-carousel Start*/
        $(".popular-destinations-hp3-carousel").owlCarousel({
            items: 1,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true
            
            
        });
        /* popular-destinations-hp3-carousel end*/
        /* slider-area-hp1 carousel Start*/
        $(".slider-area-hp1").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: false,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            dotsData: true,
            mouseDrag: false
            
            
        });
        /* slider-area-hp1 carousel end*/
        /* hp2-slider-area carousel Start*/
        $(".hp2-slider-area").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: false,
            navText: ['<i class="zmdi zmdi-long-arrow-left"></i>', '<i class="zmdi zmdi-long-arrow-right"></i>'],
            autoplay: true,
            dotsData: true
            
        });
        /* hp2-slider-area carousel end*/
        /* slider-bottom-gallery-hp1 carousel Start*/
        $(".slider-bottom-gallery-hp1").owlCarousel({
            items: 1,
            loop: true,
            dots: true,
            nav: true,
            navText: ['<i class="zmdi zmdi-chevron-left"></i>', '<i class="zmdi zmdi-chevron-right"></i>'],
            autoplay: true,
            dotsData: true
            
        });
        /* slider-bottom-gallery-hp1 carousel end*/
        /* hp1-top-destination-carousel Start*/
        $(".hp1-top-destination-carousel").owlCarousel({
            items: 4,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-chevron-left"></i>', '<i class="zmdi zmdi-chevron-right"></i>'],
            autoplay: true,
            margin: 30,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:false
                    },
                    1000:{
                        items:4,
                        autoplay:true
                    }
                }
            
        });
        /* hp1-top-destination-carousel end*/
        /*team-member-carousel-about carousel Start*/
        $(".team-member-carousel-about").owlCarousel({
            items: 4,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-chevron-left"></i>', '<i class="zmdi zmdi-chevron-right"></i>'],
            autoplay: true,
            margin: 20,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:true
                    },
                    1000:{
                        items:4,
                        autoplay:true
                    }
                }
            
        });
        /*team-member-carousel-about carousel end*/
        /*sea-tours-carousel-hp1-columns carousel Start */
        $(".sea-tours-carousel-hp1-columns").owlCarousel({
            items: 3,
            loop: true,
            dots: false,
            nav: true,
            navText: ['<i class="zmdi zmdi-chevron-left"></i>', '<i class="zmdi zmdi-chevron-right"></i>'],
            autoplay: true,
            margin: 30,
            responsive:{
                    0:{
                        items:1,
                        nav:false
                    },
                    600:{
                        items:2,
                        nav:false
                    },
                    1000:{
                        items:3,
                        autoplay:true,
                        nav:true
                        
                    }
                }
            
        });
        /*sea-tours-carousel-hp1-columns carousel end */
        /*Nice select  Start*/
        $('select').niceSelect();
        $('.world-out-video-btn').magnificPopup({
            type: 'iframe'
        });
        /*Nice select  end*/
        /*slicknav js Start*/
        $('#slicknav-menu-list').slicknav({
            allowParentLinks: true,
            prependTo:'.slicknav-menu-wrap'
        });
        /*slicknav js end*/
        /* Popup search js Start*/
        var searchicon = $('.search-icon-header');
        searchicon.on('click', function(){
            $("#popup-search-box-id").css({
                "visibility": "visible",
                "opacity": "1",
                "margin-top": "125px"
            });
        });
        
        searchicon.on('click', function(){
            $("#popup-search-box-id.hp2-search-box").css({
                "visibility": "visible",
                "opacity": "1",
                "margin-top": "170px"
            });
        });
        
        $('.close-btn-search').on('click', function(){
            $("#popup-search-box-id").css({
                "visibility": "hidden",
                "opacity": "0",
                "margin-top": "0"
            });
        });
        searchicon.on('click', function (e) {
            return false;
        });
        /* Popup search js end*/



    });
    
    $(window).scroll(function(){
        /* Sticky header js Start*/
        var headerarea = $('.header-area');
        if ($(window).scrollTop() >= 1) {
           headerarea.addClass('sticky-header-class');
        }
        else {
           headerarea.removeClass('sticky-header-class');
        }
        /* Sticky header js end*/
    });


}(jQuery));	