
function solonumeros(e) {
    var key = window.Event ? e.which : e.keyCode
    return(key >= 48 && key <= 57)
}

function validaEmail(email) {
    var regex = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    var respuesta = regex.test(email);
    return respuesta;
}

function validaRFC(rfc) {
    var regex = /^[a-zA-Z]{3,4}(\d{6})((\D|\d){2,3})?$/;
    var respuesta = regex.test(rfc);
    return respuesta;
}