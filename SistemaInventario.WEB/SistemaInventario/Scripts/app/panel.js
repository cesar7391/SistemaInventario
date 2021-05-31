
function empleados() {
    Post("Empleados/validarAccesoModulo").done(function (datos) {

        if(datos.dt == "ok") {

            window.location = fnBaseURLWeb("Empleados/Empleados");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso a este módulo',
                text: 'Contacte con el administrador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

function proveedores() {
    Post("Proveedores/validarAccesoModulo").done(function (datos) {

        if (datos.dt == "ok") {
            //LA URL A LA QUE LLEVA
            window.location = fnBaseURLWeb("Proveedores/Proveedores");

        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: 'No tiene acceso a este módulo',
                text: 'Contacte con el administrador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }
    })
}

