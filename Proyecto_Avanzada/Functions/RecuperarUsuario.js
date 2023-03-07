function BuscarCorreo() {

    $("#btnProcesar").prop("disabled", true);
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
                if (res != "") {
                    $("#btnProcesar").prop("disabled", false);
                }
                else {
                    alert("El correo ingresado no existe en el sistema");
                }
            }

        }
    });

}