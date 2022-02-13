
$(function () {
    $("#guardar_sesion").click(function () {
        var sesion = new Object();
        sesion.Correo = $('#txtcorreo').val();
        if (sesion != null) {
            $.ajax({
                type: "POST",
                url: "/Login/GuardarSesion",
                data: JSON.stringify(sesion),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    swal({
                        title: "Su Sesion Esta Siendo Guardada",
                    });
                },
                failure: function (response) {
                    alert(response.responseText);
                },
                error: function (response) {
                    alert(response.responseText);
                }
            });
        }
    });
});