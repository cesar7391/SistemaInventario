$(document).ready(function () {
    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();
})

/* Visualizar imagen*/
$("#imagen").change(function () {

    let imagen = this.files[0];

    if (imagen["type"] != "image/jpeg" && imagen["type"] != "image/png") {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("Debe subir una imagen en formato jpeg o png");
    } else if (imagen["size"] > 2000000) {
        $("#imagen").val("");
        $(".previsualizar").attr("src", "../Content/img/img_logo/TuLogo.png");
        alert("La imagen debe tener como máximo 2 MB");
    } else {
        var datosImagen = new FileReader;
        datosImagen.readAsDataURL(imagen);

        $(datosImagen).on("load", function (event) {
            var rutaImagen = event.target.result;
            $(".previsualizar").attr("src", rutaImagen);
        })
    }
})

//Funciones para validar los radiobutton y que muestre u oculte la parte de impuesto
$("#rdsi").on("click", function () {
    document.getElementById("rdno").checked = false;
    document.getElementById("rdsi").checked = true;
    $("#divvendeimpuestos").show();
})
$("#rdno").on("click", function () {
    document.getElementById("rdsi").checked = false;
    document.getElementById("rdno").checked = true;
    $("#divvendeimpuestos").hide();
})

//validaciones del botón SIGUIENTE
$("#btnsiguiente").on("click", function () {
    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtemail").val();

    if (razonsocial == "") {
        $("#msjrazonsocial").html("* El campo razón social es obligatorio").css("color", "RED");
        $("#txtrazonsocial").css("border-color", "RED");
        $("#txtrazonsocial").focus();
    } else if (ruc == "") {
        $("#msjruc").html("* El campo RUC es obligatorio").css("color", "RED");
        $("#txtruc").css("border-color", "RED");
        $("#txtruc").focus();
    } else if (email == "") {
        $("#msjemail").html("* El campo email es obligatorio").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
        $("#txtemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* La dirección de email no es válida").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
        $("#txtemail").focus();
    } else {
        var paramss = new Object();
        paramss.razonsocial = razonsocial;
        paramss.ruc = ruc;
        paramss.email = email;
        //Post de GOLBAL
        Post("RegistroEmpresa/validarRegistro", paramss).done(function (datos) {
            if (datos.dt.response == "OK") {
                $(".divregistroempresa").hide();
                $(".divregistrousersuperadmin").show();
                document.getElementById('btnregistrar').disabled = true;
            } else {
                swal({
                    position: "top-end",
                    type: "error",
                    title: datos.dt.response,
                    text: 'Por favor valida el campo solicitado',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        })
    }
})

$("#txtrazonsocial").keyup(function () {
    let razonsocial = $("#txtrazonsocial").val();
    if (razonsocial == "") {
        $("#msjrazonsocial").html("* El campo razón social es obligatorio").css("color", "RED");
        $("#txtrazonsocial").css("border-color", "RED");
    } else {
        $("#msjrazonsocial").html("").css("color", "RED");
        $("#txtrazonsocial").css("border-color", "");
    }
})

$("#txtruc").keyup(function () {
    let ruc = $("#txtruc").val();
    if (ruc == "") {
        $("#msjruc").html("* El campo RFC es obligatorio").css("color", "RED");
        $("#txtruc").css("border-color", "RED");
    } else {
        $("#msjruc").html("").css("color", "RED");
        $("#txtruc").css("border-color", "");
    }
})

$("#txtemail").keyup(function () {
    let email = $("#txtemail").val();
    if (email == "") {
        $("#msjemail").html("* El campo email es obligatorio").css("color", "RED");
        $("#txtemail").css("border-color", "RED");
    } else {
        if (!validaEmail(email)) {
            $("#msjemail").html("* La dirección de email no es válida").css("color", "RED");
            $("#txtemail").css("border-color", "RED");
        } else {
            $("#msjemail").html("").css("color", "RED");
            $("#txtemail").css("border-color", "");
        }        
    }
})

$("#btnregistrar").on("click", function () {
    debugger;
    let razonsocial = $("#txtrazonsocial").val();
    let ruc = $("#txtruc").val();
    let email = $("#txtemail").val();
    let idpais = $("#slpais").val();
    let idmoneda = $("#slmoneda").val();
    let direccion = $("#txtdireccion").val();

    let tipoimpuesto = 0
    let porcentaje = 0
    let vendeimpuesto = 0;

    let username = $("#txtusername").val();
    let usuario = $("#txtusuario").val();
    let contraseña = $("#txtcontraseña").val();
    let contraseña2 = $("#txtconfirmarcontraseña").val();

    if ($("#rdsi").is(":checked") == true) {
        tipoimpuesto = $("#sltipoimpuesto").val();
        porcentaje = $("#slporcentaje").val();
        vendeimpuesto = 1;
    }

    if (username == "") {
        $("#msjusername").html("El campo nombre administrador no debe estar vacío").css("color", "RED");
        $("#txtusername").css("border-color", "red");
        $("#txtusername").focus();
    } else if (usuario == "") {
        $("#msjusuario").html("El campo usuario no debe estar vacío").css("color", "RED");
        $("#txtusuario").css("border-color", "red");
        $("#txtusuario").focus();
    } else if (contraseña == "") {
        $("#msjpassword").html("La contraseña no debe estar vacía").css("color", "RED");
        $("#txtcontraseña").css("border-color", "red");
        $("#txtcontraseña").focus();
    } else if (contraseña2 == "") {
        $("#msjpassword2").html("No se ha confirmado la contraseña").css("color", "RED");
        $("#txtconfirmarcontraseña").css("border-color", "red");
        $("#txtconfirmarcontraseña").focus();
    } else {
        debugger;
        let params = new FormData();
        let slfile = ($("#imagen"))[0].files[0];
        params.append("file", slfile);
        params.append("razonsocial", razonsocial);
        params.append("ruc", ruc);
        params.append("email", email);
        params.append("idpais", idpais);
        params.append("idmoneda", idmoneda);
        params.append("direccion", direccion);
        params.append("idimpuesto", tipoimpuesto);
        params.append("idporcentaje", porcentaje);
        params.append("vendeimpuesto", vendeimpuesto);
        params.append("username", username);
        params.append("usuario", usuario);
        params.append("contraseña", contraseña);

        PostImg("RegistroEmpresa/insertarEmpresa", params).done(function (datos) {

            if (datos.dt.response == "ok") {
               swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Empresa guardada correctamente',
                    text: 'Se envió un correo con sus accesos',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
               }).then((result) => {
                   if (result.value) {
                       window.location = fnBaseURLWeb("Home/Index");
                   } else {
                       window.location = fnBaseURLWeb("Home/Index");
                   }
               })
           } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: 'No se guardó la empresa',
                    text: 'Contacte con el administrador del sistema',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
           }

        })
    }
})

$("#btncancelar").on("click", function () {
    window.location = fnBaseURLWeb("Home/Index");
})

$("#btnatras").on("click", function () {
    $(".divregistroempresa").show();
    $(".divregistrousersuperadmin").hide();
})
