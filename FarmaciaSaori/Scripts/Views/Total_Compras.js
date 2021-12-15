/*Total Compras*/
$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerTotalCompras,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Total_Compras").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
})