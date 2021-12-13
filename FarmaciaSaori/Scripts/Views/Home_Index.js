$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerTotalProductos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Total_Productos").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
})