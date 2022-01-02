var tabladata;

function Guardar() {

    if ($("#form").valid()) {

        var request = {
            objeto: {
                IdUsuario: $("#txtid").val()
            }
        }
        console.log(data)
        jQuery.ajax({
            url: $.MisUrls.url._GuardarSesion,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                    $('#FormModal').modal('hide');
                } else {

                    swal("Mensaje", "No se pudo guardar los cambios", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

    }

}
