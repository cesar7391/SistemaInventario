$(document).ready(function () {
    $("#lblprin").html("AGREGAR INVENTARIO");
    document.getElementById("btnagregarinventario").disabled = true;
    document.getElementById("btnajustesinventario").disabled = false;

    //Juego de botones
    $("#txtlector").show();
    $("#txtlector").focus();
    document.getElementById("btnlector").disabled = true;
    $("#txtteclado").hide();
    document.getElementById("btnteclado").disabled = false;

    //Se oculta el formulario para agregar existencias
    $(".oculto").hide();
})

$("#btnteclado").on("click", function () {
    $("#txtteclado").show();
    $("#txtteclado").focus();
    document.getElementById("btnteclado").disabled = true;
    $("#txtlector").hide();
    document.getElementById("btnlector").disabled = false;
})

$("#btnlector").on("click", function () {
    $("#txtlector").show();
    $("#txtlector").focus();
    document.getElementById("btnlector").disabled = true;
    $("#txtteclado").hide();
    document.getElementById("btnteclado").disabled = false;
})

$("#txtteclado").autocomplete({

    source: function (request, response) {
        PostAutocomplete("Productos/obtlistaProducto/", request.term).done(function (data) {
            response($.map(data, function (item) {
                return { label: item.desc, value: item.desc, id: item.idproducto, precioventa: item.precioventa, existen: item.existen };
            }))

        })
    },
    select: function (event, ui) {

        $(".oculto").show();
        let descripcion = ui.item.value;
        let pventa = ui.item.precioventa;
        let idproducto = ui.item.id;
        let hay = ui.item.existen;

        $("#lbldescripcion").html(descripcion).css("color", "Green");
        $("#lblexistencias").html(hay).css("color", "Green");
        $("#lblprecioventa").html(pventa).css("color", "Green");
        $("#txtidproducto").val(idproducto);
        //$("#txtdescripcion").val("");
    }
})

$("#txtlector").keyup(function (e) {
    e.preventDefault();
    tecla = e.which;
    cod = $("#txtlector").val();

    if (tecla == 13) {

        let params = new Object();
        params.codbarra = cod;
        Post("Productos/obtlistaProducto_cod", params).done(function (datos) {

            $(".oculto").show();
            $("#lbldescripcion").html(datos.dt[0].desc).css("color", "Green");
            $("#lblprecioventa").html(datos.dt[0].precioventa).css("color", "Green");
            $("#lblexistencias").html(datos.dt[0].existen).css("color", "Green");
            $("#txtidproducto").val(datos.dt[0].idproducto);
        })
    }
})

$("#btnagregar").on("click", function () {
    let idproducto = $("#txtidproducto").val();
    let masexistencias = $("#txtagregarcantidad").val();

    if (masexistencias.trim() == "" || parseInt(masexistencias.trim()) < 0 || masexistencias.trim() == "0") {
        alertify.error("Debe agregar existencias para añadir al inventario");
        $("#txtagregarcantidad").css("border-color", "red");
        $("#txtagregarcantidad").focus();
        return;
    } else {
        $("#txtagregarcantidad").css("border-color", "blue");

        let params = new Object();
        params.idproducto = idproducto;
        params.masexistencias = masexistencias;
        Post("Inventarios/agregarInventario", params).done(function (datos) {

            if (datos.dt.response == "ok") {
                swal({
                    position: 'top-end',
                    type: 'success',
                    title: "Se aumentó la existencia del producto",
                    text: 'success',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                }, function () {
                    window.location = fnBaseURLWeb("Inventarios/Inventarios");
                })
            } else {
                swal({
                    position: 'top-end',
                    type: 'error',
                    title: datos.dt.response,
                    text: 'por favor valide lo solicitado o contacte con el administrador',
                    showConfirmButton: true,
                    timer: 60000,
                    confirmButtonText: 'Cerrar'
                })
            }
        })
    }
})

$("#txtagregarcantidad").keyup(function () {
    let masExistencias = $("#txtagregarcantidad").val();
    $("#lblmensaje").html("Se añadirán " + masExistencias+" existencias al inventario");
})