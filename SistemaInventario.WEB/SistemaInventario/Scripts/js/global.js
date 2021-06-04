//Sirve para crear funciones AJAX que reciben parametros
function Post(url, paramss) {
    return ajaxMethod(url, "POST", paramss);
}

function ajaxMethod(url, method, paramss) {
    return $.ajax({
        url: window.appURL + url,
        method: method,
        async: false,
        cache: false,
        data: paramss
    }).fail(function (jqxHR, textStatus, errorThrown) {
        console.debug(jqxHR);
        console.debug(textStatus);
        console.debug(errorThrown);
    })
}

/* Función para enviar archivos file al controlador */
function PostImg(url, params) {
    return ajaxMethodImg(url, "POST", params);
}

function ajaxMethodImg(url, method, params) {
    return $.ajax({
        url: window.appURL + url,
        method: method,
        async: false,
        processData: false,
        contentType: false,
        cache: false,
        data: params
    }).fail(function (jqxHR, textStatus, errorThrown) {
        console.debug(jqxHR);
        console.debug(textStatus);
        console.debug(errorThrown);
    })
}

function PostAutocomplete(url, params) {
    return ajaxAutocomplete(url, params);
}

function ajaxAutocomplete(url, params) {
    return $.ajax({
        url: window.appURL + url,
        type: 'POST',
        contentType: "application/json",
        dataType: "json",
        data: "{ 'letra': '" + params + "'}"
    }).fail(function (jqXHR, textStatus, errorThrowm) {
        console.debug(jqXHR);
        console.debug(textStatus);
        console.debug(errorThrowm);
    })
}

//Para redireccionar a una URL dentro del proyecto
function fnBaseURLWeb(url) {
    return window.appURL + url;
}