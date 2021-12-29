
var table;



$(document).ready(function () {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '< Ant',
        nextText: 'Sig >',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sá'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };


    $.datepicker.setDefaults($.datepicker.regional['es']);
    activarMenu("Reportes");

    $("#txtFechaInicio").datepicker();
    $("#txtFechaFin").datepicker();
    $("#txtFechaInicio").val(ObtenerFecha());
    $("#txtFechaFin").val(ObtenerFecha());


    //OBTENER TIENDAS
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerDetalleFarmaco,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#cboTienda").LoadingOverlay("hide");
            $("#cboTienda").html("");

            $("<option>").attr({ "value": 0 }).text("-- Seleccionar todas--").appendTo("#cboTienda");
            if (data.data != null)
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdDetalleFarmaco }).text(item.NombreComercial).appendTo("#cboTienda");
                    }
                })
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $("#cboTienda").LoadingOverlay("show");
        },
    });

});

$('#btnBuscar').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerReporteVenta + "?fechainicio=" + $("#txtFechaInicio").val() + "&fechafin=" + $("#txtFechaFin").val() + "&idtienda=" + $("#cboTienda").val() ,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $("#tbReporte tbody").html("");


                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td>").text(row["FechaVenta"]),
                        $("<td>").text(row["NumeroDocumento"]),
                        $("<td>").text(row["TipoDocumento"]),
                        $("<td>").text(row["NombreComercial"]),
                        $("<td>").text(row["Concentracion"]),
                        $("<td>").text(row["NombreEmpleado"]),
                        $("<td>").text(row["CantidadUnidadesVendidas"]),
                        $("<td>").text(row["CantidadProductos"]),
                        $("<td>").text(row["TotalVenta"])

                    ).appendTo("#tbReporte tbody");

                })

            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
})



function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}

function printData() {

    if ($('#tbReporte tbody tr').length == 0) {
        swal("Mensaje", "No existen datos para imprimir", "warning")
        return;
    }

    var divToPrint = document.getElementById("tbReporte");

    var style = "<style>";
    style = style + "table {width: 100%;font: 17px Calibri;}";
    style = style + "table, th, td {border: solid 1px #DDD; border-collapse: collapse;";
    style = style + "padding: 2px 3px;text-align: center;}";
    style = style + "</style>";

    newWin = window.open("");


    newWin.document.write(style);
    newWin.document.write("<div style='text-align:center; padding:10px;background: rgb(71,0,138);background: linear-gradient(90deg, rgba(71, 0, 138, 1) 0%, rgba(140, 17, 255, 1) 35%, rgba(0, 212, 255, 1) 100%);-webkit-print-color-adjust: exact;border-radius:0 15px 0 15px;' id='back_head'>");
    newWin.document.write("<h2 style='color:white;'>Reporte de Compras Farmacia Saori</h2>");
    newWin.document.write("<h3 style='color:white;'>San Juan, La Concepción</h3>");
    newWin.document.write("<h3 style='color:white;'>Tel: +505 8170-7927</h3>");
    newWin.document.write("</div>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}