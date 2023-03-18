function BuscarCorreo() {

    $("#btnRegistrar").prop("disabled", true);
    let correo = $("#CorreoElectronico").val();

    $.ajax({
        url: "/Home/BuscarCorreo",
        type: "POST",
        data: {
            "correo": correo
        },
        dataType: 'json',
        success: function (res) {

            if (res != "ERROR") {
                if (res == "") {
                    $("#btnRegistrar").prop("disabled", false);
                }
                else {
                    alert(res);
                }
            }

        }
    });

}

function ConsultarNombreApi() {

    let Identificacion = $("#Identificacion").val();

    if (Identificacion.trim().length >= 8) {

        $.ajax({
            url: "https://apis.gometa.org/cedulas/" + Identificacion,
            type: "GET",
            dataType: 'json',
            success: function (res) {
                $("#Nombre").val(res.nombre);
            }
        });

    }
    else {
        $("#Nombre").val("");
    }

}