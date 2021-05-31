$(document).ready(function () {
    //Se usa punto para referenciar clase, # para referenciar id
    $(".divnewprovedor").hide();
    $("#lblinicial").html("Proveedores");
})

$("#btnnewproveedor").on("click", function () {
    $(".divnewprovedor").show();
    $("#divlistaproveedores").hide();   
    $("#lblinicial").html("Nuevo Proveedor");
})

$("#btnregistrar").on("click", function () {
    
    let ruc = $("#txtpruc").val();
    let razonsocial = $("#txtprazonsocial").val();
    let email = $("#txtpemail").val();
    let telefono = $("#txtptelefono").val();    
    let direccion = $("#txtpdireccion").val();

    if (ruc.trim() == "") {
        $("#msjruc").html("* Ingrese el RFC del proveedor").css("color", "red");
        $("#txtpruc").css("border-color", "red");
        $("#txtpruc").focus();
    } else if (razonsocial.trim() == "") {
        $("#msjrazonsocial").html("* Ingrese la razón social").css("color", "red");
        $("#txtprazonsocial").css("border-color", "red");
        $("#txtprazonsocial").focus();
    } else if (telefono.trim() == "") {
        $("#msjtelefonos").html("* Ingrese un teléfono del proveedor").css("color", "red");
        $("#txtptelefono").css("border-color", "red");
        $("#txtptelefono").focus();
    } else if (email.trim() == "") {
        $("#msjemail").html("* Ingrese un email del proveedor").css("color", "red");
        $("#txtpemail").css("border-color", "red");
        $("#txtpemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* Ingrese un email válido").css("color", "red");
        $("#txtpemail").css("border-color", "red");
        $("#txtpemail").focus();
    } else if (direccion.trim() == "") {
        $("#msjdireccion").html("* Ingrese la dirección").css("color", "red");
        $("#txtpdireccion").css("border-color", "red");
        $("#txtpdireccion").focus();
    } else {

        var params = new Object();
        params.ruc = ruc;
        params.razonsocial = razonsocial;
        params.telefono = telefono;
        params.email = email;
        params.direccion = direccion;

        Post("Proveedores/registrarProveedor", params).done(function (data) {
            debugger;
            if (data.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: "Proveedor registrado correctamente",
                    text: 'success',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }, function () {
                    window.location = fnBaseURLWeb("Proveedores/Proveedores");
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: data.dt.response,
                    text: 'por favor valide lo solicitado o contacte con el administrador',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        })
    }
})