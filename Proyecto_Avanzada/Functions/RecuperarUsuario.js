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

                    Swal.fire({
                        icon: 'error',
                        title: 'Oops...',
                        text: 'El correo ingresado no existe en el sistema!',
                        
                    })
                  
                }
            }

        }
    });
    
}

