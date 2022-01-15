
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

});

$('#btnBuscar').on('click', function () {

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerReporteDevolucionCompra + "?fechainicio=" + $("#txtFechaInicio").val() + "&fechafin=" + $("#txtFechaFin").val(),
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data != undefined && data != null) {

                $("#tbReporte tbody").html("");


                $.each(data, function (i, row) {

                    $("<tr>").append(
                        $("<td style='color:black'>").text(row["FechaDevolucion"]),
                        $("<td style='color:black'>").text(row["Codigo"]),
                        $("<td style='color:black'>").text(row["NombreEmpleado"]),
                        $("<td style='color:black'>").text(row["RazonSocial"]),
                        $("<td style='color:black'>").text(row["NombreComercial"]),
                        $("<td style='color:black'>").text(row["Cantidad"]),
                        $("<td style='color:black'>").text(row["Concepto"])

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

    var header_ = document.getElementById("header-reporte-compraimg");
    var divToPrint = document.getElementById("tbReporte");


    var style = "<style>";
    style = style + "table {width: 100%;font-family:'MesloLGL Nerd Font'; font - size: 10px;}";
    style = style + "table, th{border-collapse: collapse;background: #6F85E8;color:white;text-align:start;border:1px solid white;padding: 4px;}";
    style = style + "table, td {color:black;border: 1px solid #e1e1e1;";
    style = style + "padding: 4px;}";
    style = style + "</style>";

    newWin = window.open("");

    newWin.document.write(style);
    newWin.document.write("<div style='text-align:center; padding:10px;background: rgb(2,0,36);background:linear-gradient(90deg,rgba(2,0,36,1)0%, rgba(9,9,121,1) 35%, rgba(0,212,255,1) 100%);-webkit-print-color-adjust: exact;border-radius:0 15px 0 15px;' id='back_head'>");
    newWin.document.write("<h2 style='color:white;'>Reporte de Devolucion/Proveedor Farmacia Saori</h2>");
    newWin.document.write("<h3 style='color:white;'>San Juan, La Concepción</h3>");
    newWin.document.write("<h3 style='color:white;'>Tel: +505 8170-7927</h3>");
    newWin.document.write("</div>");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}