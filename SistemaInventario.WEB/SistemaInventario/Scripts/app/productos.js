
$(document).ready(function () {
    $("#lblprin").html("CATÁLOGO DE PRODUCTOS");

    document.getElementById("txtapartir").disabled = true;

    /*    
    document.getElementById("btncatalogo").disabled = true;
    $("#sldepartbuscar").select2();
    $(".selectpicker").select2();
    $(".ocultar").hide();
    */
})

$("#btnnewp").on("click", function () {

    $("#lblprin").html("NUEVO PRODUCTO");
    document.getElementById("divcatalogo").style.display = "none";
    document.getElementById("divnewproduct").style.display = "block";

    document.getElementById("rdrbien").checked = true;
    document.getElementById("rdrservicio").checked = false;
    
    document.getElementById("rdrunca").checked = true;
    $("#lblpvenser").html("Precio venta");

    document.getElementById("txtexist").disabled = false;
    document.getElementById("txtcodbarra").disabled = false;
    document.getElementById("txtstockmin").disabled = false;
    
})

$("#rdrbien").on("click", function () {

    document.getElementById("rdrservicio").checked = false;
    document.getElementById("rdrbien").checked = true;

    document.getElementById("rdrunca").checked = true;
    document.getElementById("rdrkigra").checked = false;
    document.getElementById("txtpcosto").disabled = false;
    document.getElementById("txtganancia").disabled = false;
    document.getElementById("txtpvenser").disabled = true;

    $("#lblpvenser").html("Precio venta");
    document.getElementById("txtpmayoreo").disabled = false;
    document.getElementById("txtapartir").disabled = false;
    $("#txtfvenci").val("dd/mm/aaaa");
    document.getElementById("txtfvenci").disabled = false;
    document.getElementById("chknoaplica").checked = false;
    document.getElementById("chknoaplica").disabled = false;

    $("#txtcodbarra").val("");
    $("#txtdesc").val("");
    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");

    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");
    //document.getElementById("chkimpuestos").checked = false;

    $("#txtpmayoreo").val("");
    $("#txtapartir").val("");
    $("#sldepart").val("0");

    $("#txtexist").val("");
    $("#txtstockmin").val("");

    document.getElementById("rdrkigra").disabled = false;
    document.getElementById("txtexist").disabled = false;
    document.getElementById("txtcodbarra").disabled = false;
    document.getElementById("txtstockmin").disabled = false;
})

$("#rdrservicio").on("click", function () {

    document.getElementById("rdrbien").checked = false;
    document.getElementById("rdrservicio").checked = true;

    document.getElementById("rdrunca").checked = true;
    document.getElementById("rdrkigra").checked = false;
    document.getElementById("txtpcosto").disabled = true;
    document.getElementById("txtganancia").disabled = true;
    document.getElementById("txtpvenser").disabled = false;
    
    $("#lblpvenser").html("Precio del servicio: ");    
    document.getElementById("txtpmayoreo").disabled = true;    
    document.getElementById("txtapartir").disabled = true;    
    $("#txtfvenci").val("dd/mm/aaaa");
    document.getElementById("txtfvenci").disabled = true;
    document.getElementById("chknoaplica").checked = true;
    document.getElementById("chknoaplica").disabled = true;

    $("#txtcodbarra").val("");
    $("#txtdesc").val("");
    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");

    $("#txtpcosto").val("");
    $("#txtganancia").val("");
    $("#txtpvenser").val("");
    //document.getElementById("chkimpuestos").checked = false;

    $("#txtpmayoreo").val("");
    $("#txtapartir").val("");
    $("#sldepart").val("0");

    $("#txtexist").val("");
    $("#txtstockmin").val("");
    
    document.getElementById("rdrkigra").disabled = true;
    document.getElementById("txtexist").disabled = true;
    document.getElementById("txtcodbarra").disabled = true;
    document.getElementById("txtstockmin").disabled = true;
})

$("#rdrunca").on("click", function () {
    document.getElementById("rdrunca").checked = true;
    document.getElementById("rdrkigra").checked = false;
})

$("#rdrkigra").on("click", function () {
    document.getElementById("rdrunca").checked = false;
    document.getElementById("rdrkigra").checked = true;
})

$("#chknoaplica").on("click", function () {

    let chknoaplica = document.getElementById("chknoaplica").checked;

    if (chknoaplica) {
        $("#txtfvenci").val("dd/mm/aaaa");
        document.getElementById("txtfvenci").disabled = true;
    } else {
        $("#txtfvenci").val("dd/mm/aaaa");
        document.getElementById("txtfvenci").disabled = false;
    }
})

$("#txtganancia").keyup(function () {

    let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();

    if (pcosto != "") {

        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/calcularPventaSinImpuestos", params).done(function (datos) {

            if (datos.dt != null) {
                $("#txtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#txtpvenser").val("");
            }
        })

    } else {
        alertify.error("El precio de costo no debe estar vacío");
        //$("#txtganancia").css("border-color", "RED");
    }
})

$("#txtpcosto").keyup(function () {

    let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();

    if (pcosto.trim() != "") {

        let params = new Object();
        params.pcosto = pcosto;
        params.ganancia = ganancia;
        Post("Productos/calcularPventaSinImpuestos", params).done(function (datos) {

            if (datos.dt != null) {
                $("#txtpvenser").val(separadorDecimales(datos.dt.pventa.toFixed(2)));
            } else {
                $("#txtpvenser").val("");
            }
        })
    } else {
        alertify.error("El precio de costo no debe estar vacío");
        $("#txtpcosto").css("border-color", "RED");
    }
})

$("#txtpmayoreo").keyup(function () {

    //Se obtienen los valores de los txt mayoreo y venta
    let pmayoreo = $("#txtpmayoreo").val();
    let pventa = $("#txtpvenser").val();

    let params = new Object();
    params.pmayoreo = pmayoreo;
    params.pventa = pventa;

    Post("Productos/calculoPrecios", params).done(function (datos) {

        if (datos.dt == "ok") {
            if (pmayoreo.trim() != "") {
                document.getElementById("txtapartir").disabled = false;
                $("#txtpmayoreo").css("border-color", "");
            } else {
                document.getElementById("txtapartir").disabled = true;
                $("#txtapartir").val("");
                $("#txtpmayoreo").css("border-color", "");
            }
        } else {
            alertify.error("El precio mayoreo no debe ser mayor al precio de venta");
            $("#txtpmayoreo").css("border-color", "RED");
        }
    })    
})

$("#txtapartir").keyup(function () {

    let pmayoreo = $("#txtpmayoreo").val();
    let apartir = $("#txtapartir").val();

    if (pmayoreo.trim() == "") {
        document.getElementById("txtapartir").disabled = true;
        $("#txtapartir").val("");
    } else {
        if (apartir < 2) {
            alertify.error("Deben ser más de 2 productos para utilizar el precio de mayoreo");
            $("#txtapartir").val("");
            $("#txtapartir").focus();
            $("#txtapartir").css("border-color", "RED");
        } else {
            $("#txtapartir").css("border-color", "");
        }
    }
})

/*
 * GUARDAR PRODUCTO
 */

$("#btnguardar").on("click", function () {

    let tipo = 0;
    let rdbien = document.getElementById('rdrbien').checked;
    let rdservicio = document.getElementById('rdrservicio').checked;    

    let codbarra = $("#txtcodbarra").val();
    let desc = $("#txtdesc").val();

    let tproduct = 0;
    let rdrunca = document.getElementById('rdrunca').checked;
    let rdrkigra = document.getElementById('rdrkigra').checked;

    let pcosto = $("#txtpcosto").val();
    let ganancia = $("#txtganancia").val();
    let pventa = $("#txtpvenser").val();
    let pmayoreo = $("#txtpmayoreo").val();
    let apartir = $("#txtapartir").val();
    let sldepart = $("#sldepart").val();
    let existen = $("#txtexist").val();
    let minexisten = $("#txtstockmin").val();
    let fvenci = $("#txtfvenci").val();

    let sinoaplica = document.getElementById('chknoaplica').checked;
    let faplica = 0;

    if (rdservicio) {
        tipo = 2;
        if (desc.trim() == "") {
            alertify.error("Ingrese la descripción del servicio");
            $("#txtdesc").val("");
            $("#txtdesc").focus();
            $("#txtdesc").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#txtdesc").css("border-color", "");
            alertify.error("Ingrese el precio del servicio");
            $("#txtpvenser").val("");
            $("#txtpvenser").focus();
            $("#txtpvenser").css("border-color", "red");
            return false;
        } else if (sldepart.trim() == 0) {
            $("#txtpvenser").css("border-color", "");
            alertify.error("Seleccione un departamento");
            $("#sldepart").val(0);
            $("#sldepart").css("border-color", "red");
            return false;
        } else if (rdrunca) {
            tproduct = 1;
        } else if (rdrkigra) {
            tproduct = 2;
        } else {
            $("#txtpvenser").css("border-color", "");
            $("#sldepart").css("border-color", "");
            $("#txtdesc").css("border-color", "");
        }
    }

    if (rdbien) {
        tipo = 1;
        if (codbarra.trim() == "") {
            alertify.error("Ingrese el codigo de barras del producto");
            $("#txtcodbarra").val("");
            $("#txtcodbarra").focus();
            $("#txtcodbarra").css("border-color", "red");
            return false;
        } else if (desc.trim() == "") {
            $("#txtcodbarra").css("border-color", "");
            alertify.error("Ingrese la descripción del producto");
            $("#txtdesc").val("");
            $("#txtdesc").focus();
            $("#txtdesc").css("border-color", "red");
            return false;
        } else if (pcosto.trim() == "") {
            $("#txtdesc").css("border-color", "");
            alertify.error("Ingrese el precio costo del producto");
            $("#txtpcosto").val("");
            $("#txtpcosto").focus();
            $("#txtpcosto").css("border-color", "red");
            return false;
        } else if (ganancia.trim() == "") {
            $("#txtpcosto").css("border-color", "");
            alertify.error("Ingrese el % de ganancia deseada del producto");
            $("#txtganancia").val("");
            $("#txtganancia").focus();
            $("#txtganancia").css("border-color", "red");
            return false;
        } else if (pventa.trim() == "") {
            $("#txtganancia").css("border-color", "");
            alertify.error("Ingrese el precio de venta del producto");
            $("#txtpvenser").val("");
            $("#txtpvenser").focus();
            $("#txtpvenser").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() == "") {
            $("#txtpvenser").css("border-color", "");
            alertify.error("Ingrese el precio de mayoreo del producto");
            $("#txtpmayoreo").val("");
            $("#txtpmayoreo").focus();
            $("#txtpmayoreo").css("border-color", "red");
            return false;
        } else if (pmayoreo.trim() != "") {
            $("#txtganancia").css("border-color", "");
            if (apartir.trim() == "") {
                $("#txtpmayoreo").css("border-color", "");
                alertify.error("Ingrese la cantidad de productos para el precio mayoreo");
                $("#txtapartir").val("");
                $("#txtapartir").focus();
                $("#txtapartir").css("border-color", "red");
                return false;
            } else if (sldepart.trim() == 0) {
                $("#txtapartir").css("border-color", "");
                alertify.error("Seleccione un departamento");
                $("#sldepart").val(0);
                $("#sldepart").css("border-color", "red");
                return false;
            } else if (existen.trim() == "") {
                $("#sldepart").css("border-color", "");
                alertify.error("Ingrese la cantidad de existencias del producto");
                $("#txtexist").val("");
                $("#txtexist").focus();
                $("#txtexist").css("border-color", "red");
                return false;
            } else if (rdrunca) {
                $("#txtdesc").css("border-color", "");
                tproduct = 1;
            } else if (rdrkigra) {
                tproduct = 2;
            }
        }     
    }

    if (sinoaplica) {
        faplica = 1
    } else {
        if (fvenci.trim() == "") {
            alertify.error("Ingrese la fecha de vencimiento");
            $("#txtfvenci").val("");
            $("#txtfvenci").css("border-color", "red");
            $("#txtexist").css("border-color", "red");
            return false;
        } else {
            $("#txtfvenci").css("border-color", "");
        }
    }

    let params = new Object();
    params.tipo = tipo;
    params.codbarra = codbarra;
    params.desc = desc;
    params.tproduct = tproduct;
    params.pcosto = pcosto;
    params.ganancia = ganancia;
    params.pventa = pventa;
    params.pmayoreo = pmayoreo;
    params.apartir = apartir;
    params.sldepart = sldepart;
    params.existen = existen;
    params.minexisten = minexisten;
    params.fvenci = fvenci;
    params.faplica = faplica;

    Post("Productos/guardarProducto", params).done(function (datos) {

        if (datos.dt.response == 'ok') {
            swal({
                position: 'top-end',
                type: 'success',
                title: "Producto registrado correctamente",
                text: 'Guardado en la base de datos',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            }, function () {
                window.location = fnBaseURLWeb("Productos/Productos");
            })
        } else {
            swal({
                position: 'top-end',
                type: 'error',
                title: datos.dt.response,
                text: 'Valide los campos o contacte con el administrador del sistema',
                showConfirmButton: true,
                timer: 60000,
                confirmButtonText: 'Cerrar'
            })
        }

    })
})

$("#txtcodbarra").keyup(function () {
    $("#txtcodbarra").css("border-color", "BLUE");
})

$("#txtdesc").keyup(function () {
    $("#txtdesc").css("border-color", "BLUE");
})

$("#txtpcosto").keyup(function () {
    $("#txtpcosto").css("border-color", "BLUE");
})

$("#txtganancia").keyup(function () {
    $("#txtganancia").css("border-color", "BLUE");
})

$("#txtpvenser").keyup(function () {
    $("#txtpvenser").css("border-color", "BLUE");
})

$("#sldepart").keyup(function () {
    $("#sldepart").css("border-color", "BLUE");
})

$("#txtexist").keyup(function () {
    $("#txtexist").css("border-color", "BLUE");
})