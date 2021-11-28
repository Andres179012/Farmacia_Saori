﻿
var tabladata;
var tablausuario;
var tablacliente;
var tablaformap;
var tablaproducto;


$(document).ready(function () {
    activarMenu("Ventas");

    //OBTENER USUARIOS
    tablausuario = $('#tbUsuario').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerUsuarios,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_Usuario", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarusuario(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "usuario" },
        ],
        responsive: true
    });
    //OBTENER CLIENTES
    tablacliente = $('#tbCliente').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerCliente,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_Cliente", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarcliente(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "nombre_Cliente" }
        ],
        responsive: true
    });
    //OBTENER FORMA PAGO
    tablaformap = $('#tbFormaPago').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerFormaPago,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_FormaPago", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarformapago(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "forma_Pago" }
        ],

        responsive: true
    });
    //OBTENER FARMACOS
    tablaproducto = $('#tbProducto').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerProductos,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_Farmaco", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarproducto(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "nombre_Generico" },

        ],

        responsive: true
    });

})

function buscarusuario(json) {
    $("#txtIdUsuario").val(0);

    if (json != null) {

        $("#txtIdUsuario").val(json.id_Usuario);
        $("#txtNombreUsuario").val(json.usuario);

    } else {
        $("#txtNombreUsuario").val("");
    }

    $('#modalUsuario').modal('show');
}


function buscarcliente(json) {
    $("#txtIdCliente").val(0);

    if (json != null) {

        $("#txtIdCliente").val(json.id_Cliente);
        $("#txtNCliente").val(json.nombre_Cliente);

    } else {
        $("#txtNCliente").val("");

    }

    $('#modalCliente').modal('show');
}

function buscarformapago(json) {
    $("#txtformap").val(0);

    if (json != null) {

        $("#txtformap").val(json.id_FormaPago);
        $("#txtformapago").val(json.forma_Pago);

    } else {
        $("#txtformapago").val("");

    }

    $('#modalFormaPago').modal('show');
}

function buscarproducto(json) {
    $("#txtIdProducto").val(0);

    if (json != null) {

        $("#txtIdProducto").val(json.id_Farmaco);
        $("#txtNombreFarmaco").val(json.nombre_Generico);

    } else {
        $("#txtNombreFarmaco").val("");
    }

    $('#modalProducto').modal('show');
}


$("#txtIdProducto").on('keypress', function (e) {

    if (e.which == 13) {

        //OBTENER PRODUCTOS
        jQuery.ajax({
            url: $.MisUrls.url._ObtenerProducto,
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                $("#txtIdProducto").LoadingOverlay("hide");
                var encontrado = false;
                if (data.data != null) {
                    $.each(data.data, function (i, item) {
                        if (item.Activo == true && item.Codigo == $("#txtIdProducto").val()) {

                            $("#txtIdProducto").val(item.id_Farmaco);
                            $("#txtNombreFarmaco").val(item.nombre_Generico);

                            encontrado = true;
                            return false;
                        }
                    })

                    if (!encontrado) {
                        $("#txtIdFarmaco").val("0");
                        $("#txtNombreFarmaco").val("");
                    }
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {
                $("#txtIdProducto").LoadingOverlay("show");
            },
        });


    }
});

$.fn.inputFilter = function (inputFilter) {
    return this.on("input keydown keyup mousedown mouseup select contextmenu drop", function () {
        if (inputFilter(this.value)) {
            this.oldValue = this.value;
            this.oldSelectionStart = this.selectionStart;
            this.oldSelectionEnd = this.selectionEnd;
        } else if (this.hasOwnProperty("oldValue")) {
            this.value = this.oldValue;
            this.setSelectionRange(this.oldSelectionStart, this.oldSelectionEnd);
        } else {
            this.value = "";
        }
    });
};

$("#txtCantidadFarmaco").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});

$("#txtPrecioVentaFarmaco").inputFilter(function (value) {
    return /^-?\d*[.]?\d{0,2}$/.test(value);
});


$('#btnAgregarVenta').on('click', function () {

    var existe_codigo = false;
    if (
        parseInt($("#txtNombreUsuario").val()) == 0 ||
        parseInt($("#txtNCliente").val()) == 0 ||
        parseInt($("#txtformapago").val()) == 0 ||
        parseInt($("#txtNombreFarmaco").val()) == 0 ||
        parseFloat($("#txtCantidadFarmaco").val()) == 0 ||
        parseFloat($("#txtPrecioVentaFarmaco").val()) == 0
    ) {
        swal("Mensaje", "Debe completar todos los campos", "warning")
        return;
    }

    $('#tbVenta > tbody  > tr').each(function (index, tr) {
        var fila = tr;
        var codigoproducto = $(fila).find("td.codigoproducto").text();

        if (codigoproducto == $("#txtIdProducto").val()) {
            existe_codigo = true;
            return false;
        }

    });

    if (!existe_codigo) {
        $("<tr>").append(
            $("<td>").append(
                $("<button>").addClass("btn btn-danger btn-sm").text("Eliminar")
            ),
            $("<td>").append($("#txtNombreUsuario").val()),
            $("<td>").append($("#txtNCliente").val()),
            $("<td>").append($("#txtformapago").val()),
            $("<td>").append($("#txtNombreFarmaco").val()),
            $("<td>").addClass("#txtcantidad").append($("#txtCantidadFarmaco").val()),
            $("<td>").addClass("#txtprecioventa").append($("#txtPrecioVentaFarmaco").val()),
        ).appendTo("#tbVenta tbody");

        $("#txtIdProducto").val("0");
        $("#txtCodigoFarmaco").val("");
        $("#txtNombreFarmaco").val("");
        $("#txtCantidadFarmaco").val("0");
        $("#txtPrecioVentaFarmaco").val("0");

    } else {
        swal("Mensaje", "El producto ya existe en la compra", "warning")
    }
})

$('#tbVenta tbody').on('click', 'button[class="btn btn-danger btn-sm"]', function () {
    $(this).parents("tr").remove();
})



$('#btnTerminarGuardarVenta').on('click', function () {


    if ($('#tbCompra > tbody  > tr').length == 0) {
        swal("Mensaje", "No existen detalles", "warning")
        return;
    }

    var $xml = "";
    var compra = "";
    var detallecompra = ""
    var detalle = "";
    var totalcostocompra = 0;

    $xml = "<DETALLE>";
    compra = "<COMPRA>" +
        "<Id_Proveedor>" + $("#txtIdProveedor").val() + "</Id_Proveedor>" +
        "<Id_Laboratorio>" + $("#txtLab").val() + "</Id_Laboratorio>" +
        "<Sub_Total>!subtotal¡</Sub_Total>" +
        "<Descuento>!descuento¡</Descuento>" +
        "<IVA>!iva¡</Iva>" +
        "<Total>!total¡</Total>" +
        "</COMPRA>";
    detallecompra = "<DETALLE_COMPRA>"

    $('#tbCompra > tbody  > tr').each(function (index, tr) {

        var fila = tr;
        var idFarmaco = parseFloat($(fila).find("td.codigoproducto").data("id_Farmaco"));
        var idFormafarmaceutica = parseFloat($(fila).find("td.idFormaFarmaceutica").text());
        var idFormapago = parseFloat($(fila).find("td.idFormaPago").text());
        var CantidadCompra = parseFloat(cantidad) * parseFloat(cantidad_Compra);
        var preciocompra = parseFloat($(fila).find("td.precioCompra").text());
        var lote = parseFloat($(fila).find("td.lote").text());
        var unitario = parseFloat($(fila).find("td.unitario").text());

        detalle = detalle + "<DETALLE>" +
            "<IdCompra>0</IdCompra>" +
            "<Id_Farmaco>" + idFarmaco + "</Id_Farmaco>" +
            "<Id_FormaFarmaceutica>" + idFormafarmaceutica + "</Id_FormaFarmaceutica>" +
            "<Id_FormaPago>" + idFormapago + "</Id_FormaPago>" +
            "<Cantidad_Compra>" + CantidadCompra + "</Cantidad_Compra>" +
            "<Precio_Compra>" + preciocompra + "</Precio_Compra>" +
            "<Lote>" + lote + "</Lote>" +
            "<Unitario>" + unitario + "</Unitario>" +
            "</DETALLE>";

        subtotal = CantidadCompra * preciocompra;
        totaldescuento = subtotal * descuento;
        IVA = subtotal * (15 / 100);
        totalcostocompra = subtotal + IVA - totaldescuento;

    });

    compra = compra.replace("!total¡", totalcostocompra.toString());
    $xml = $xml + compra + detallecompra + detalle + "</DETALLE_COMPRA></DETALLE>";

    var request = { xml: $xml };



    jQuery.ajax({
        url: $.MisUrls.url._GuardarCompra,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {
            $.LoadingOverlay("hide");

            if (data.resultado) {

                //PROVEEDOR
                $("#txtIdProveedor").val("0");
                $("#txtNombre").val("");
                $("#txtDireccion").val("");
                $("#txtTelefono").val("");

                //LABORATORIO
                $("#txtLab").val("0");
                $("#txtLaboratorio").val("");

                //FORMA FARMACEUTICA
                $("#txtformaf").val("0");
                $("#txtformafar").val("");

                //FORMA PAGO
                $("#txtformap").val("0");
                $("#txtformapago").val("");

                //FARMACO
                $("#txtIdProducto").val("0");
                $("#txtNombreFarmaco").val("");
                $("#txtCantidadFarmaco").val("0");
                $("#txtPrecioCompraFarmaco").val("0");

                $("#tbCompra tbody").html("");

                swal("Mensaje", "Se registro la compra", "success")
            } else {

                swal("Mensaje", "No se pudo registrar la compra", "warning")
            }
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $.LoadingOverlay("show");
        },
    });



})
