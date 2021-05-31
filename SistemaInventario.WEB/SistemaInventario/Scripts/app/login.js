
let password = document.getElementById('txtpassword');

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

$("#btningresar").on("click", function () {
    let ruc = $("#txtruc").val();
    let user = $("#txtuser").val();
    let pass = $("#txtpassword").val();

    if (ruc == "") {
        $("#msjruc").html("* Ingrese un RFC").css("color", "RED");
    } else if (user == "") {
        $("#msjuser").html("* Ingrese un usuario").css("color", "RED");
    } else if (pass == "") {
        $("#msjpassword").html("* Ingrese la contraseña").css("color", "RED");
    } else {
        var params = new Object();
        params.ruc = ruc;
        params.user = user;
        params.pass = pass;
        Post("Login/Acceder", params).done(function (datos) {
            if (datos.dt.response == "ok") {
                window.location = fnBaseURLWeb("Panel/Panel");
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
        });
    }
})

$("#txtruc").keyup(function () {
    $("#msjruc").html("").css("color", "BLUE");
})
$("#txtuser").keyup(function () {
    $("#msjuser").html("").css("color", "BLUE");
})
$("#txtpassword").keyup(function () {
    $("#msjpassword").html("").css("color", "BLUE");
})