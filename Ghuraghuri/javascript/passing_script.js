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
function addToCart(id) {
    window.location.href = "Cart.aspx?data=" + encodeURIComponent(id);
}

function validateNonNegative(textBox) {
    var value = parseInt(textBox.value);
    if (value <= 0) {
        textBox.value = 1
    }
   
}

