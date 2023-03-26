function BuscarCorreo() {

    $("#btnRegistrar").prop("disabled", true);
    let correo = $("#CorreoElectronico").value;

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

function ConsultarNombreApi(field) {
    let Identificacion = field.value;


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
        console.log($);
        $("#Nombre").val("");
    }

}
