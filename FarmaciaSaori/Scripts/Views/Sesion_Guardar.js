function Guardar() {
    alert("entre");
    $.ajax({
        url: $.MisUrls.url._GuardarSesion,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        data: {
            IdUsuario: $("#txtid").val(),
            Correo: $("#txtcorreo").val()
        },
        success: function (respuesta) {
            swal("Mensaje", "Sesion Guardada", "warning")
        }
    });
}
