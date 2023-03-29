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
                    $("#CorreoElectronico").val("");
                   
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'El correo ingresado ya existe en el sistema!',


                    })

                }
            }

        }
    });

}

function BuscarCorreo2() {

    $(id = "btnLogin").prop("disabled", true);
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
                    $("#CorreoElectronico").val("");
                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: '¡El correo ingresado no existe en el sistema!',
                    })

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
