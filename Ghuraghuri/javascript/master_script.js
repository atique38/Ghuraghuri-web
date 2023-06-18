let navbar = document.querySelector('.header .nav');
document.querySelector('#menu').onclick = () => {
    navbar.classList.add('active');
}

document.querySelector('#nav_close').onclick = () => {
    navbar.classList.remove('active');
}



window.onscroll = () => {
    navbar.classList.remove('active');

    if (window.scrollY > 0) {
        document.querySelector('.header').classList.add('active');
    }
    else {
        document.querySelector('.header').classList.remove('active');
    }
}

window.onload = () => {


    if (window.scrollY > 0) {
        document.querySelector('.header').classList.add('active');
    }
    else {
        document.querySelector('.header').classList.remove('active');
    }
}