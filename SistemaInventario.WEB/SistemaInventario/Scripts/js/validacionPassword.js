document.getElementById("btnregistrar").disabled = true;

let password = document.getElementById('txtcontraseña');
let confirmarpassword = document.getElementById('txtconfirmarcontraseña');

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

$("#txtcontraseña").keyup(function () {
    let contraseña = $("#txtcontraseña").val();
    let contraseña2 = $("#txtconfirmarcontraseña").val();
    if (contraseña == "") {
        password.setAttribute('type', 'password');
        $("#faeyeslash").hide();
        $("#faeye").show();
        $("#msjpassword").html("").css("color", "RED");
    } else {
        $("#faeye").show();
        if (!/[A-Z]/.test(contraseña)) {
            $("#msjpassword").html("Debe tener al menos una mayúscula").css("color", "RED");
            $("#txtcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[a-z]/.test(contraseña)) {
            $("#msjpassword").html("Debe tener al menos una minúscula").css("color", "RED");
            $("#txtcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[#@!$%=&?¿¡!]/.test(contraseña)) {
            $("#msjpassword").html("Debe tener al menos un caracter especial").css("color", "RED");
            $("#txtcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contraseña.length < 8) {
            $("#msjpassword").html("Debe tener al menos 8 caracteres").css("color", "RED");
            $("#txtcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contraseña2 != "") {
            if (contraseña != contraseña2) {
                $("#msjpassword").html("¡Las contraseñas no coinciden!").css("color", "RED");
                $("#txtcontraseña").css("border-color", "red");
                document.getElementById("btnregistrar").disabled = true;
            } else {
                $("#msjpassword2").html("").css("color", "RED");
                $("#msjpassword").html("").css("color", "RED");
                $("#txtcontraseña").css("border-color", "BLUE");
                $("#txtconfirmarcontraseña").css("border-color", "BLUE");
                document.getElementById("btnregistrar").disabled = false;
            }
        } else {
            $("#msjpassword").html("").css("color", "RED");
            $("#txtcontraseña").css("border-color", "");
            document.getElementById("btnregistrar").disabled = false;
        }
    }
})

//*******************************************************************************

$("#faeye2").on("click", function () {
    if (confirmarpassword.type == 'password') {
        confirmarpassword.setAttribute('type', 'text');
        $("#faeye2").hide();
        $("#faeyeslash2").show();
    }
})
$("#faeyeslash2").on("click", function () {
    if (confirmarpassword.type == 'text') {
        confirmarpassword.setAttribute('type', 'password');
        $("#faeyeslash2").hide();
        $("#faeye2").show();
    }
})

$("#txtconfirmarcontraseña").keyup(function () {
    let contraseña = $("#txtcontraseña").val();
    let contraseña2 = $("#txtconfirmarcontraseña").val();
    if (contraseña2 == "") {
        password.setAttribute('type', 'password');
        $("#faeyeslash2").hide();
        $("#faeye2").show();
        $("#msjpassword2").html("").css("color", "RED");
    } else {
        $("#faeye2").show();
        if (!/[A-Z]/.test(contraseña2)) {
            $("#msjpassword2").html("Debe tener al menos una mayúscula").css("color", "RED");
            $("#txtconfirmarcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[a-z]/.test(contraseña2)) {
            $("#msjpassword2").html("Debe tener al menos una minúscula").css("color", "RED");
            $("#txtconfirmarcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (!/[#@!$%=&?¿¡!]/.test(contraseña2)) {
            $("#msjpassword2").html("Debe tener al menos un caracter especial").css("color", "RED");
            $("#txtconfirmarcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contraseña2.length < 8) {
            $("#msjpassword2").html("Debe tener al menos 8 caracteres").css("color", "RED");
            $("#txtconfirmarcontraseña").css("border-color", "red");
            document.getElementById("btnregistrar").disabled = true;
        } else if (contraseña != "") {
            if (contraseña2 != contraseña2) {
                $("#msjpassword2").html("¡Las contraseñas no coinciden!").css("color", "RED");
                $("#txtconfirmarcontraseña").css("border-color", "red");

                document.getElementById("btnregistrar").disabled = true;
            } else {

                $("#msjpassword2").html("").css("color", "RED");
                $("#msjpassword").html("").css("color", "RED");
                $("#txtcontraseña").css("border-color", "BLUE");
                $("#txtconfirmarcontraseña").css("border-color", "BLUE");
                document.getElementById("btnregistrar").disabled = false;
            }
        } else {
            $("#msjpassword2").html("").css("color", "RED");
            $("#txtconfirmarcontraseña").css("border-color", "");
            document.getElementById("btnregistrar").disabled = false;
        }
    }
})

