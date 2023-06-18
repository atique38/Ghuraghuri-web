var swiper = new Swiper(".home_slider", {
    loop: true,
    grabCursor: true,
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
});

var swiper = new Swiper(".product-slider", {
   
    grabCursor: true,
    spaceBetween: 20,
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        0: {
            slidesPerView: 2,

        },
        640: {
            slidesPerView: 3,

        },
        820: {
            slidesPerView: 3,

        },
        1024: {
            slidesPerView: 4,
        },
    },
});

var swiper = new Swiper(".blog-slider", {
   
    grabCursor: true,
    spaceBetween: 10,
    // navigation: {
    //   nextEl: ".swiper-button-next",
    //   prevEl: ".swiper-button-prev",
    // },

    breakpoints: {
        0: {
            slidesPerView: 1,

        },
        768: {
            slidesPerView: 2,

        },
        991: {
            slidesPerView: 3,

        },

    },
});


var swiper = new Swiper(".t_spot-slider", {
    // loop:true,
    grabCursor: true,
    spaceBetween: 10,
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        0: {
            slidesPerView: 2,

        },
        640: {
            slidesPerView: 3,

        },
        820: {
            slidesPerView: 3,

        },
        1024: {
            slidesPerView: 4,
        },
    },
});

var swiper = new Swiper(".box_container-slider", {
    // loop:true,
    grabCursor: true,
    spaceBetween: 10,
    navigation: {
        nextEl: ".swiper-button-next",
        prevEl: ".swiper-button-prev",
    },
    breakpoints: {
        0: {
            slidesPerView: 2,

        },
        640: {
            slidesPerView: 3,

        },
        820: {
            slidesPerView: 3,

        },
        1024: {
            slidesPerView: 4,
        },
    },
});

function spotClicked(name) {
    window.location.href = "SpotDetails.aspx?data=" + encodeURIComponent(name);
}

function blogClicked(id) {
    window.location.href = "BlogDetails.aspx?data=" + encodeURIComponent(id);
}

function packageClicked(id) {
    window.location.href = "PackageDetails.aspx?data=" + encodeURIComponent(id);
}
function productClicked(id) {
    window.location.href = "ProductDetails.aspx?data=" + encodeURIComponent(id);
}