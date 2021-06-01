
$(document).ready(function () {
    $("#lblprin").html("CATÁLOGO DE PRODUCTOS");

    /*
    document.getElementById("txtapartir").disabled = true;
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