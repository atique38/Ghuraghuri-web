let popup = document.querySelector('.popup');
let popup2 = document.querySelector('.popup_phone');
let popup3 = document.querySelector('.popup_gender');
let popup4 = document.querySelector('.popup_agency');
let popup5 = document.querySelector('.popup_owner');
let popup6 = document.querySelector('.popup_agency_phone');
let popup7 = document.querySelector('.popup_address');



document.querySelector('#name_edt').onclick = () => {
    popup.classList.add('open');
}
document.querySelector('#phone_edt').onclick = () => {
    popup2.classList.add('open');

}
document.querySelector('#gender_edt').onclick = () => {
    popup3.classList.add('open');

}
document.querySelector('#agency_edt').onclick = () => {
    popup4.classList.add('open');

}
document.querySelector('#owner_edt').onclick = () => {
    popup5.classList.add('open');

}
document.querySelector('#agency_phone_edt').onclick = () => {
    popup6.classList.add('open');

}
document.querySelector('#address_edt').onclick = () => {
    popup7.classList.add('open');

}




document.querySelector('#name_close').onclick = () => {
    popup.classList.remove('open'); 
}
document.querySelector('#phone_close').onclick = () => {
    popup2.classList.remove('open');
}
document.querySelector('#gender_close').onclick = () => {
    popup3.classList.remove('open');
}
document.querySelector('#agency_close').onclick = () => {
    popup4.classList.remove('open');
}
document.querySelector('#owner_close').onclick = () => {
    popup5.classList.remove('open');
}
document.querySelector('#agency_phone_close').onclick = () => {
    popup6.classList.remove('open');
}
document.querySelector('#address_close').onclick = () => {
    popup7.classList.remove('open');
}

function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            var v = document.getElementById('imgview');
            v.setAttribute("src", e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

function setImage(url) {
    var v = document.getElementById('imgview');
    v.setAttribute("src", url);
}