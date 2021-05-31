
$(document).ready(function () {
    $("#divregistrarempleados").hide();
    $("#diveditarempleados").hide();
    $("#divlistaempleados").show();

    $("#lblinicial").html("Empleados");
})


$("#btnnewempleado").on("click", function () {

    Post("Empleados/validarCantUsers").done(function (datos) {
        if (datos.dt.response == "ok") {
            $("#lblinicial").html("Nuevo Empleado");
            $("#divregistrarempleados").show();
            $("#divlistaempleados").hide();
            

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'Superó la cantidad de usuarios registrados',
                text: 'Contacte con el administrador del sistema o compre una nueva licencia',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
})

$("#btnregistrar").on("click", function () {
    let nombre = $("#txtusername").val();
    let dni = $("#txtdni").val();
    let email = $("#txtemail").val();
    let user = $("#txtusuario").val();
    let password = $("#txtcontraseña").val();
    let slcargo = $("#slcargo").val();

    let ischventas = document.getElementById('chventas').checked;
    let ischclientes = document.getElementById('chclientes').checked;
    let ischcaja = document.getElementById('chcaja').checked;
    let ischcompras = document.getElementById('chcompras').checked;
    let ischproductos = document.getElementById('chproductos').checked;
    let ischinventario = document.getElementById('chinventario').checked;
    let ischproveedores = document.getElementById('chproveedores').checked;
    let ischdashboard = document.getElementById('chdashboard').checked;
    let ischusuarios = document.getElementById('chusuarios').checked;
    let ischempresa = document.getElementById('chempresa').checked;
    let ischconfiguraciones = document.getElementById('chconfiguraciones').checked;

    let ventas = 0;
    let clientes = 0;
    let caja = 0;
    let compras = 0;
    let productos = 0;
    let inventario = 0;
    //se cambió
    let proveedores = 0;
    let dashboard = 0;
    let usuarios = 0;
    let empresa = 0;
    let configuraciones = 0;

    if (nombre.trim() == "") {
        $("#msjnombre").html("* Ingrese un nombre de cliente").css("color", "red");
        $("#txtusername").css("border-color", "red");
        $("#txtusername").focus();
    } else if (dni.trim() == "") {
        $("#msjdni").html("* Ingrese el DNI del cliente").css("color", "red");
        $("#txtdni").css("border-color", "red");
        $("#txtdni").focus();
    } else if (email.trim() == "") {
        $("#msjemail").html("* Ingrese un email de cliente").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjemail").html("* Ingrese un email válido").css("color", "red");
        $("#txtemail").css("border-color", "red");
        $("#txtemail").focus();
    } else if (user.trim() == "") {
        $("#msjusuario").html("* Ingrese el usuario del cliente").css("color", "red");
        $("#txtusuario").css("border-color", "red");
        $("#txtusuario").focus();
    } else if (password.trim() == "") {
        $("#msjcontraseña").html("* Ingrese la contraseña para el cliente").css("color", "red");
        $("#txtcontraseña").css("border-color", "red");
        $("#txtcontraseña").focus();
    } else if (!/[A-Z]/.test(password) || !/[a-z]/.test(password) || !/[#@!$%=&?¿¡!]/.test(password) || password.length < 8) {
        $("#msjcontraseña").html("* La contraseña no cumple con los requisitos").css("color", "red");
        $("#txtcontraseña").css("border-color", "red");
        $("#txtcontraseña").focus();
    } else if (slcargo == 0) {
        $("#msjcargo").html("* Seleccione un cargo").css("color", "red");
    } else if (ischventas || ischclientes || ischcaja || ischcompras
        || ischproductos || ischinventario || ischproveedores || ischdashboard
        || ischusuarios || ischempresa || ischconfiguraciones) {
        if (ischventas) { ventas = 1 }
        if (ischclientes) { clientes = 1 }
        if (ischcaja) { caja = 1 }
        if (ischcompras) { compras = 1 }
        if (ischproductos) { productos = 1 }
        if (ischinventario) { inventario = 1 }
        if (ischproveedores) { proveedores = 1 }
        if (ischdashboard) { dashboard = 1 }
        if (ischusuarios) { usuario = 1 }
        if (ischempresa) { empresa = 1 }
        if (ischconfiguraciones) { configuraciones = 1 }

        let idcargo = document.getElementById("slcargo");
        let stringcargo = idcargo.options[idcargo.selectedIndex].text;

        var paramss = new Object();

        paramss.nombre = nombre;
        paramss.dni = dni;
        paramss.email = email;
        paramss.user = user;
        paramss.password = password;
        paramss.slcargo = stringcargo;

        paramss.ventas = ventas;
        paramss.clientes = clientes;
        paramss.caja = caja;
        paramss.compras = compras;
        paramss.productos = productos;
        paramss.inventario = inventario;
        //se cambió, igual en update
        paramss.proveedor = proveedores;
        paramss.dashboard = dashboard;
        paramss.usuarios = usuarios;
        paramss.empresa = empresa;
        paramss.configuraciones = configuraciones;

        Post("Empleados/registrarUsuario", paramss).done(function (data) {

            if (data.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Usuario registrado correctamente',
                    text: 'Se enviaron las credenciales al correo del usuario',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }, function () {
                    window.location = fnBaseURLWeb("Empleados/Empleados");
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: data.dt.response,
                    text: 'Por favor, valide lo solicitado o contacte con el administrador',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }

        })

    } else {
        swal({
            position: 'top-end',
            type: 'error',
            title: 'Debe seleccionar al menos un acceso',
            text: 'Por favor, valide lo solicitado',
            showConfirmButton: true,
            timer: 60000,
            confirmButtonText: 'Cerrar'
        })
    }
})

$("#txtusername").keyup(function () {
    $("#msjnombre").html("").css("color", "");
    $("#txtusername").css("border-color", "BLUE");
})

$("#txtdni").keyup(function () {
    $("#msjdni").html("").css("color", "");
    $("#txtdni").css("border-color", "BLUE");
})

$("#txtemail").keyup(function () {
    $("#msjemail").html("").css("color", "");
    $("#txtemail").css("border-color", "BLUE");
})

$("#txtusuario").keyup(function () {
    $("#msjusuario").html("    ").css("color", "");
    $("#txtusuario").css("border-color", "BLUE");
})

$("#btnvolver").on("click", function () {
    window.location = fnBaseURLWeb("Empleados/Empleados");
})

$("#slcargo").on("click", function () {

    let slcargo = $("#slcargo").val();

    if (slcargo == 0) {

        $("#msjcargo").html("* Seleccione un cargo").css("color", "red");
        document.getElementById('chventas').checked = false;

    } else {

        if (slcargo == 1) {
            document.getElementById('chventas').checked = true;
        } else {
            document.getElementById('chventas').checked = false;
        }

        $("#msjcargo").html("").css("color", "BLUE");
    }

})

$("#txtcontraseña").keyup(function () {

    let contraseña = $("#txtcontraseña").val();

    if (contraseña.trim() == "") {
        password.setAttribute('type', 'password');
        $("#faeyeslash").hide();
        $("#faeye").show();
        $("#msjcontraseña").html("").css("color", "red");
    } else {
        $("#faeye").show();

        if (!/[A-Z]/.test(contraseña)) {
            $("#msjcontraseña").html("* Debe tener al menos una mayúscula").css("color", "red");
            $("#txtcontraseña").css("border-color", "red");

        } else if (!/[a-z]/.test(contraseña)) {
            $("#msjcontraseña").html("* Debe tener al menos una minúscula").css("color", "red");
            $("#txtcontraseña").css("border-color", "red");

        } else if (!/[#@!$%=&?¿¡!]/.test(contraseña)) {
            $("#msjcontraseña").html("* Debe tener al menos un caracter especial").css("color", "red");
            $("#txtcontraseña").css("border-color", "red");

        } else if (contraseña.length < 8) {
            $("#msjcontraseña").html("* Debe tener como mínimo 8 caracteres").css("color", "red");
            $("#txtcontraseña").css("border-color", "red");

        } else {
            $("#msjcontraseña").html("").css("color", "");
            $("#txtcontraseña").css("border-color", "");
        }
    }    
})

let password = document.getElementById('txtcontraseña');

$("#faeye").on("click", function () {
    if (password.type == 'password') {
        password.setAttribute('type', 'text');
        $("#faeye").hide();
        $("#faeyeslash").show();
    }
})
$("#faeyeslash").on("click", function () {
    if (password.type == 'text') {
        password.setAttribute('type', 'password');
        $("#faeyeslash").hide();
        $("#faeye").show();
    }
})

/****************************************
 * ACTIVAR EMPLEADO
 * *************************************/
$(".tablas").on("click", ".btnactivar", function () {

    //Busque dentro de la tabla el id que tiene "Activar"
    let iduser = $(this).attr("Activar")

    swal({
        title: '¿Está seguro de activar al empleado?',
        text: 'Si no lo está, puede cancelar la acción',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        CancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Activar',
        closeOnConfirm: false
    }, function (isConfirm) {
            if (isConfirm) {
                let params = new Object();
                params.iduser = iduser;
                //alert(iduser);
                Post("Empleados/activarEmpleado", params).done(function (datos) {
                    if (datos.dt.response == "ok") {
                        swal({
                            position: 'top-end',
                            type: 'success',
                            title: 'Se activó al empleado correctamente',
                            text: 'Empleado activado',
                            showConfirmButton: true,
                            timer: 60000,
                            confirmButtonText: 'Cerrar'
                        }, function () {
                            window.location = fnBaseURLWeb("Empleados/Empleados");
                        })
                    } else {
                        swal({
                            position: 'top-end',
                            type: 'error',
                            title: datos.dt.response,
                            text: 'Contacte con el administrador del sistema o compre una licencia de usuarios',
                            showConfirmButton: true,
                            timer: 60000,
                            confirmButtonText: 'Cerrar'
                        })
                    }
                })
            }
    })
})

/****************************************
 * DESACTIVAR
 * *************************************/
$(".tablas").on("click", ".btndesactivar", function () {

    //Busque dentro de la tabla el id que tiene "Desactivar"
    let iduser = $(this).attr("Desactivar")

    swal({
        title: '¿Está seguro de desactivar al empleado?',
        text: 'Si no lo está, puede cancelar la acción',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        CancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Desactivar',
        closeOnConfirm: false
    }, function (isConfirm) {
        if (isConfirm) {
            let params = new Object();
            params.iduser = iduser;
            Post("Empleados/desactivarEmpleado", params).done(function (datos) {
                if (datos.dt.response == "ok") {
                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: 'Se desactivó al empleado correctamente',
                        text: 'Empleado desactivado',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    }, function () {
                        window.location = fnBaseURLWeb("Empleados/Empleados");
                    })
                } else {
                    swal({
                        position: 'top-end',
                        type: 'error',
                        title: datos.dt.response,
                        text: 'Contacte con el administrador del sistema',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
        }
    })
})

/****************************************
 * ELIMINAR EMPLEADO
 * *************************************/
$(".tablas").on("click", ".btneliminar", function () {

    //Busque dentro de la tabla el id que tiene "Eliminar"
    let iduser = $(this).attr("Eliminar")

    swal({
        title: '¿Está seguro de eliminar completamente al empleado?',
        text: 'Si no lo está, puede cancelar la acción',
        type: 'warning',
        showConfirmButton: true,
        showCancelButton: true,
        ConfirmButtonColor: '#3085d6',
        CancelButtonColor: '#d33',
        CancelButtonText: 'Cancelar',
        confirmButtonText: 'Eliminar',
        closeOnConfirm: false
    }, function (isConfirm) {
        if (isConfirm) {
            let params = new Object();
            params.iduser = iduser;
            Post("Empleados/eliminarEmpleado", params).done(function (datos) {
                if (datos.dt.response == "ok") {
                    swal({
                        position: 'top-end',
                        type: 'success',
                        title: 'Se eliminó al empleado correctamente',
                        text: 'Empleado eliminado',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    }, function () {
                        window.location = fnBaseURLWeb("Empleados/Empleados");
                    })
                } else {
                    swal({
                        position: 'top-end',
                        type: 'error',
                        title: datos.dt.response,
                        text: 'Contacte con el administrador del sistema',
                        showConfirmButton: true,
                        timer: 60000,
                        confirmButtonText: 'Cerrar'
                    })
                }
            })
        }
    })
})

/****************************************
 * OBTENER EMPLEADO
 * *************************************/
$(".tablas").on("click", ".btneditar", function () { 
    
    let iduser = $(this).attr("editar");
    let params = new Object()
    params.idUser = iduser;
    Post("Empleados/obteditarEmpleado", params).done(function (datos) {

        if (datos.dt.response == "ok") {
            $("#lblinicial").html("Editar Empleado");
            
            $("#divregistrarempleados").hide();
            $("#diveditarempleados").show();
            $("#divlistaempleados").hide();            

            //SE OBTIENEN LOS DATOS PARA MOSTRAR EN EL FORMULARIO
            debugger;
            $("#txtiduser").val(datos.dt.idUser);
            $("#txteditusername").val(datos.dt.username);
            $("#txteditdni").val(datos.dt.dni);
            $("#txteditemail").val(datos.dt.email);
            $("#txteditusuario").val(datos.dt.user);

            //Se obtienen los valores para el select
            $("#obt").append("<option value=" + datos.dt.idcargo + ">" + datos.dt.cargo + "</option");

            if (datos.dt.ventas == 1) { document.getElementById('cheditventas').checked = true; }
            if (datos.dt.clientes == 1) { document.getElementById('cheditclientes').checked = true; }
            if (datos.dt.caja == 1) { document.getElementById('cheditcaja').checked = true; }
            if (datos.dt.compras == 1) { document.getElementById('cheditcompras').checked = true; }
            if (datos.dt.productos == 1) { document.getElementById('cheditproductos').checked = true; }
            if (datos.dt.inventario == 1) { document.getElementById('cheditinventario').checked = true; }
            if (datos.dt.proveedor == 1) { document.getElementById('cheditproveedores').checked = true; }
            if (datos.dt.dashboard == 1) { document.getElementById('cheditdashboard').checked = true; }
            if (datos.dt.usuarios == 1) { document.getElementById('cheditusuarios').checked = true; }
            if (datos.dt.empresa == 1) { document.getElementById('cheditempresa').checked = true; }
            if (datos.dt.configuraciones == 1) { document.getElementById('cheditconfiguraciones').checked = true; }

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: datos.dt.response,
                text: 'Contacte con el creador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
})

$("#btneditpass").on("click", function () {
    if ($("#txteditcontraseña").prop('disabled') == true) {
        $("#txteditcontraseña").prop('disabled', false);
        $("#txteditcontraseña").val("");
    } else {
        $("#txteditcontraseña").prop('disabled', true);
        $("#txteditcontraseña").val("**********");
    }
})

$("#txteditcontraseña").keyup(function () {

    let contraseña = $("#txteditcontraseña").val();

    if (contraseña.trim() == "") {
        password.setAttribute('type', 'password');
        $("#faeyeslashedir").hide();
        $("#faeyeedit").show();
        $("#msjeditcontraseña").html("").css("color", "red");
    } else {
        $("#faeye").show();

        if (!/[A-Z]/.test(contraseña)) {
            $("#msjeditcontraseña").html("* Debe tener al menos una mayúscula").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");

        } else if (!/[a-z]/.test(contraseña)) {
            $("#msjeditcontraseña").html("* Debe tener al menos una minúscula").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");

        } else if (!/[#@!$%=&?¿¡!]/.test(contraseña)) {
            $("#msjeditcontraseña").html("* Debe tener al menos un caracter especial").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");

        } else if (contraseña.length < 8) {
            $("#msjeditcontraseña").html("* Debe tener como mínimo 8 caracteres").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");

        } else {
            $("#msjeditcontraseña").html("").css("color", "");
            $("#txteditcontraseña").css("border-color", "");
        }
    }
})

let passwordedit = document.getElementById('txteditcontraseña');

$("#faeyeedit").on("click", function () {
    if (passwordedit.type == 'password') {
        passwordedit.setAttribute('type', 'text');
        $("#faeyeedit").hide();
        $("#faeyeslashedit").show();
    }
})
$("#faeyeslashedit").on("click", function () {
    if (passwordedit.type == 'text') {
        passwordedit.setAttribute('type', 'password');
        $("#faeyeslashedit").hide();
        $("#faeyeedit").show();
    }
})

$("#btneditvolver").on("click", function () {
    window.location = fnBaseURLWeb("Empleados/Empleados");
})

/****************************************
 * EDITAR EMPLEADO
 * *************************************/

$("#btneditar").on("click", function () {

    let iduser = $("#txtiduser").val();
    let nombre = $("#txteditusername").val();
    let dni = $("#txteditdni").val();
    let email = $("#txteditemail").val();
    let user = $("#txteditusuario").val();

    let password = "0"; 
    if ($("#txteditcontraseña").prop('disabled') == false) {
        password = $("#txteditcontraseña").val();
    }

    let slcargo = $("#sleditcargo").val();

    let ischventas = document.getElementById('cheditventas').checked;
    let ischclientes = document.getElementById('cheditclientes').checked;
    let ischcaja = document.getElementById('cheditcaja').checked;
    let ischcompras = document.getElementById('cheditcompras').checked;
    let ischproductos = document.getElementById('cheditproductos').checked;
    let ischinventario = document.getElementById('cheditinventario').checked;
    let ischproveedores = document.getElementById('cheditproveedores').checked;
    let ischdashboard = document.getElementById('cheditdashboard').checked;
    let ischusuarios = document.getElementById('cheditusuarios').checked;
    let ischempresa = document.getElementById('cheditempresa').checked;
    let ischconfiguraciones = document.getElementById('cheditconfiguraciones').checked;

    let ventas = 0;
    let clientes = 0;
    let caja = 0;
    let compras = 0;
    let productos = 0;
    let inventario = 0;
    let proveedores = 0;
    let dashboard = 0;
    let usuarios = 0;
    let empresa = 0;
    let configuraciones = 0;

    if (nombre.trim() == "") {
        $("#msjeditnombre").html("* Ingrese un nombre de cliente").css("color", "red");
        $("#txteditusername").css("border-color", "red");
        $("#txteditusername").focus();
    } else if (dni.trim() == "") {
        $("#msjeditdni").html("* Ingrese el DNI del cliente").css("color", "red");
        $("#txteditdni").css("border-color", "red");
        $("#txteditdni").focus();
    } else if (email.trim() == "") {
        $("#msjeditemail").html("* Ingrese un email de cliente").css("color", "red");
        $("#txteditemail").css("border-color", "red");
        $("#txteditemail").focus();
    } else if (!validaEmail(email)) {
        $("#msjeditemail").html("* Ingrese un email válido").css("color", "red");
        $("#txteditemail").css("border-color", "red");
        $("#txteditemail").focus();
    } else if (user.trim() == "") {
        $("#msjeditusuario").html("* Ingrese el usuario del cliente").css("color", "red");
        $("#txteditusuario").css("border-color", "red");
        $("#txteditusuario").focus();
    } else if ($("#txteditcontraseña").prop('disabled') == false) {
        if (password.trim() == "") {
            $("#msjeditcontraseña").html("* Ingrese la contraseña para el cliente").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");
            $("#txteditcontraseña").focus();
            return false;
        } else if (!/[A-Z]/.test(password) || !/[a-z]/.test(password) || !/[#@!$%=&?¿¡!]/.test(password) || password.length < 8) {
            $("#msjeditcontraseña").html("* La contraseña no cumple con los requisitos").css("color", "red");
            $("#txteditcontraseña").css("border-color", "red");
            $("#txteditcontraseña").focus();
            return false;
        }
    }

    if (slcargo == 0) {
        $("#msjeditcargo").html("* Seleccione un cargo").css("color", "red");
    } else if (ischventas || ischclientes || ischcaja || ischcompras
        || ischproductos || ischinventario || ischproveedores || ischdashboard
        || ischusuarios || ischempresa || ischconfiguraciones) {
        if (ischventas) { ventas = 1 }
        if (ischclientes) { clientes = 1 }
        if (ischcaja) { caja = 1 }
        if (ischcompras) { compras = 1 }
        if (ischproductos) { productos = 1 }
        if (ischinventario) { inventario = 1 }
        if (ischproveedores) { proveedores = 1 }
        if (ischdashboard) { dashboard = 1 }
        if (ischusuarios) { usuarios = 1 }
        if (ischempresa) { empresa = 1 }
        if (ischconfiguraciones) { configuraciones = 1 }

        let idcargo = document.getElementById("sleditcargo");
        let stringcargo = idcargo.options[idcargo.selectedIndex].text;

        var paramss = new Object();
        paramss.iduser = iduser;
        paramss.nombre = nombre;
        paramss.dni = dni;
        paramss.email = email;
        paramss.user = user;
        paramss.password = password;
        paramss.slcargo = stringcargo;

        paramss.ventas = ventas;
        paramss.clientes = clientes;
        paramss.caja = caja;
        paramss.compras = compras;
        paramss.productos = productos;
        paramss.inventario = inventario;
        paramss.proveedor = proveedores;
        paramss.dashboard = dashboard;
        paramss.usuarios = usuarios;
        paramss.empresa = empresa;
        paramss.configuraciones = configuraciones;

        Post("Empleados/editarEmpleado", paramss).done(function (data) {

            if (data.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: 'Usuario actualizado correctamente',
                    text: 'Avisar al empleado si se cambió la contraseña',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }, function () {
                    window.location = fnBaseURLWeb("Empleados/Empleados");
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: data.dt.response,
                    text: 'Por favor, valide lo solicitado o contacte con el administrador',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }

        })

    } else {
        swal({
            position: 'top-end',
            type: 'error',
            title: 'Debe seleccionar al menos un acceso',
            text: 'Por favor, valide lo solicitado',
            showConfirmButton: true,
            timer: 60000,
            confirmButtonText: 'Cerrar'
        })
    }
})

$("#cerrarModulo").on("click", function () {
    window.location = fnBaseURLWeb("Panel/Panel");
})





