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

/*Total Ventas*/
$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerTotalVentas,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Total_Ventas").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
})


$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerTotalCategorias,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Total_Categorias").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
})


//Ventas por dia
$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerVentasDia,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Ventas_Dia").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
})


//Ventas Por Mes
$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerVentaPorMes,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            console.log(data)

            document.getElementById("Ventas_Mes").innerText = data.data;
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {

        },
    });
    activarMenu("Home");
});



$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerClientesHome,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $(".customers").html("");


                $.each(data, function (i,row) {

                    $("<div class='customers-list-item d-flex align-items-center border-top border-bottom p-2 cursor-pointer'>").append(
                        $("<div class='ms-2'>").append(
                            $("<h6 class='mb-1 font-14'>").text(row["Nombre"]),
                            $("<p class='mb-0 font-13 text-secondary'>").text(row["Telefono"]),
                        ),
                        $("<div class='list-inline d-flex customers-contacts ms-auto'>").append(
                            $("<a class='list-inline-item'><i class='bx bxs-envelope'></i></a>"),
                            $("<a class='list-inline-item'><i class='bx bxs-phone'></i></a>"),
                            $("<a class='list-inline-item'><i class='bx bx-dots-vertical-rounded'></i></a>"),
                        ),
                    ).appendTo(".customers");

                })

            }

        },
    });
});

$(document).ready(function () {
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerTopProductos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $(".topProducts").html("");


                $.each(data, function (i, row) {

                    $("<div class='customers-list-item d-flex align-items-center border-top border-bottom p-2 cursor-pointer'>").append(
                        $("<a class='list-inline-item'><i class='bx bxs-cart-alt bx-sm'></i></a>"),
                        $("<div class='ms-2'>").append(
                            $("<h5 class='mb-1 font-14'>").text(row["NombreComercial"]),
                        ),
                        $("<div class='list-inline d-flex customers-contacts ms-auto'>").append(
                            $("<h5 class='mb-1 font-14'>C$</h5>"),
                            $("<h5 class='mb-1 font-14'>").text(row["MASVENDIDO"]),
                        ),
                    ).appendTo(".topProducts");

                })

            }

        },
    });
});

