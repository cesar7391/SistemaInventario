$(document).ready(function () {
    //Se usa punto para referenciar clase, # para referenciar id
    $(".divnewprovedor").hide();
    $(".diveditprovedor").hide();
    $("#lblinicial").html("Proveedores");
})

$("#btnnewproveedor").on("click", function () {
    $(".divnewprovedor").show();
    $("#divlistaproveedores").hide();   
    $("#lblinicial").html("Nuevo Proveedor");
})

/*************************
 REGISTRAR PROVEEDOR
 ************************/

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
        $("#msjtelefono").html("* Ingrese un teléfono del proveedor").css("color", "red");
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
                    text: 'Guardado en la base de datos',
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

$("#txtpruc").keyup(function () {
    $("#msjruc").html("").css("color", "red");
    $("#txtpruc").css("border-color", "BLUE");
})

$("#txtprazonsocial").keyup(function () {
    $("#msjrazonsocial").html("").css("color", "red");
    $("#txtprazonsocial").css("border-color", "BLUE");
})

$("#txtptelefono").keyup(function () {
    $("#msjtelefono").html("").css("color", "red");
    $("#txtptelefono").css("border-color", "BLUE");
})

$("#txtpemail").keyup(function () {
    $("#msjemail").html("").css("color", "red");
    $("#txtpemail").css("border-color", "BLUE");
})

$("#txtpdireccion").keyup(function () {
    $("#msjdireccion").html("").css("color", "red");
    $("#txtpdireccion").css("border-color", "BLUE");
})

$("#btnvolver").on("click", function () {
    window.location = fnBaseURLWeb("Proveedores/Proveedores");
})

$("#cerrarModulo").on("click", function () {
    window.location = fnBaseURLWeb("Panel/Panel");
})

/*************************
 ACTIVAR PROVEEDOR
 ************************/

$(".tablas").on("click", ".btnactivar", function () {

    let idprov = $(this).attr("Activar");

    swal({
        title: '¿Está seguro de activar al proveedor?',
        text: '¡Si no lo esta puede cancelar la accion!',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Si, Activar',
        closeOnConfirm: false
    }, function (isConfirm) {
        //debugger;
        if (isConfirm) {
            let params = new Object();
            params.idprov = idprov
            Post("Proveedores/activarProveedor", params).done(function (datos) {

                if (datos.dt.response == "ok") {

                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: "Se activó al proveedor correctamente",
                        text: 'Proveedor activado',
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
                        title: datos.dt.response,
                        text: 'Contacte con el administrador',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
        }
    })
})

/*************************
 DESACTIVAR PROVEEDOR
 ************************/

$(".tablas").on("click", ".btndesactivar", function () {

    let idprov = $(this).attr("Desactivar");

    swal({
        title: '¿Está seguro de desactivar al proveedor?',
        text: 'Si no lo está, puede cancelar la accion',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Si, Desactivar',
        closeOnConfirm: false
    }, function (isConfirm) {
        //debugger;
        if (isConfirm) {
            let params = new Object();
            params.idprov = idprov
            Post("Proveedores/desactivarProveedor", params).done(function (datos) {

                if (datos.dt.response == "ok") {
                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: "Se desactivó al proveedor correctamente",
                        text: 'Proveedor desactivado',
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
                        title: datos.dt.response,
                        text: 'Contacte con su administrador',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
        }

    })

})

/*************************
 ELIMINAR PROVEEDOR
 ************************/

$(".tablas").on("click", ".btneliminar", function () {

    let idprov = $(this).attr("Eliminar");

    swal({
        title: '¿Está seguro de eliminar al proveedor?',
        text: '¡Si no lo está, puede cancelar la accion!',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Si, Eliminar',
        closeOnConfirm: false
    }, function (isConfirm) {
        //debugger;
        if (isConfirm) {
            let params = new Object();
            params.idprov = idprov
            Post("Proveedores/eliminarProveedor", params).done(function (datos) {

                if (datos.dt.response == "ok") {

                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: "Se eliminó al proveedor correctamente",
                        text: 'Proveedor eliminado',
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
                        title: datos.dt.response,
                        text: 'Contacte con su administrador',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
        }
    })
})

/*************************
 OBTENER PROVEEDOR
 ************************/

$(".tablas").on("click", ".btneditar", function () {
    //trae el id del proveedor
    let idprov = $(this).attr("editar");

    let params = new Object();
    params.idprov = idprov
    Post("Proveedores/obteditarProveedor", params).done(function (datos) {

        if (datos.dt.response = "ok") {
            debugger;
            $("#divlistaproveedores").hide();
            $(".divnewprovedor").hide();        
            $(".diveditprovedor").show();

            $("#lblinicial").html("Editar Proveedores");

            $("#idprov").val(datos.dt.idprov);
            $("#txteditpruc").val(datos.dt.ruc);
            $("#txteditprazonsocial").val(datos.dt.razonsocial);
            $("#txteditptelefono").val(datos.dt.telefono);
            $("#txteditpemail").val(datos.dt.email);
            $("#txteditpdireccion").val(datos.dt.direccion);

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: datos.dt.response,
                text: 'Contacte con su administrador',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
})

/*************************
 EDITAR PROVEEDOR
 ************************/

$("#btneditar").on("click", function () {
    let idprov = $("#idprov").val();
    let ruc = $("#txteditpruc").val();
    let razonsocial = $("#txteditprazonsocial").val();
    let telefono = $("#txteditptelefono").val();
    let email = $("#txteditpemail").val();
    let direccion = $("#txteditpdireccion").val();

    if (ruc.trim() == "") {
        $("#msjeditruc").html("* Ingrese el RFC del proveedor").css("color", "red");
        $("#txteditpruc").css("border-color", "red");
        $("#txteditpruc").focus();
    } else if (razonsocial.trim() == "") {
        $("#msjeditrazonsocial").html("* Ingrese la razón social").css("color", "red");
        $("#txteditprazonsocial").css("border-color", "red");
        $("#txteditprazonsocial").focus();
    } else if (telefono.trim() == "") {
        $("#msjedittelefonos").html("* Ingrese el telefono del proveedor").css("color", "red");
        $("#txteditptelefono").css("border-color", "red");
        $("#txteditptelefono").focus();
    } else if (email.trim() == "") {
        $("#msjeditemail").html("* Ingrese un email del proveedor").css("color", "red");
        $("#txtpemail").css("border-color", "red");
        $("#txteditpemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* Ingrese un email válido").css("color", "red");
        $("#txteditpemail").css("border-color", "red");
        $("#txteditpemail").focus();
    } else if (direccion.trim() == "") {
        $("#msjeditdireccion").html("* Ingrese la dirección").css("color", "red");
        $("#txteditpdireccion").css("border-color", "red");
        $("#txteitpdireccion").focus();
    } else {

        var params = new Object();
        params.idprov = idprov
        params.ruc = ruc;
        params.razonsocial = razonsocial;
        params.telefono = telefono;
        params.email = email;
        params.direccion = direccion;

        Post("Proveedores/editarProveedor", params).done(function (data) {
            //debugger;
            if (data.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: "Proveedor editado correctamente",
                    text: 'Se ha editado la información',
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

$("#btneditvolver").on("click", function () {
    window.location = fnBaseURLWeb("Proveedores/Proveedores");
})
