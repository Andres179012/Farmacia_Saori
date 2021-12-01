
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
        var idproducto = $(fila).find("td.id_Farmaco").text();

        if (idproducto == $("#txtIdProducto").val()) {
            existe_codigo = true;
            return false;
        }

    });

    if (!existe_codigo) {
        $("<tr>").append(
            $("<td>").append(
                $("<button>").addClass("btn btn-danger btn-sm").text("Eliminar")
            ),
            $("<td>").addClass("codigoproducto").data("idproducto", $("#txtIdProducto").val()),
            $("<td>").addClass("usuario").data("user", $("#txtIdUsuario").val()).append($("#txtNombreUsuario").val()),
            $("<td>").addClass("cliente").data("client", $("#txtIdCliente").val()).append($("#txtNCliente").val()),
            $("<td>").addClass("formaP").data("fp", $("#txtIdFormap").val()).append($("#txtformapago").val()),
            $("<td>").addClass("nombreF").data("nf", $("#txtIdProducto").val()).append($("#txtNombreFarmaco").val()),
            $("<td>").addClass("catidad").data("cf", $("#txtCantidadFarmaco").val()).append($("#txtCantidadFarmaco").val()),
            $("<td>").addClass("precioV").data("pv", $("#txtPrecioVentaFarmaco").val()).append($("#txtPrecioVentaFarmaco").val()),
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


    if ($('#tbVenta > tbody  > tr').length == 0) {
        swal("Mensaje", "No existen detalles", "warning")
        return;
    }

    var $xml = "";
    var venta = "";
    var detalleventa = ""
    var detalle = "";
    var totalcostocompra = 0;

    var subtotalFinal = 0.0;
    var ivaFinal = 0.0;
    var totalFinal = 0.0;
    var descuentoFinal = 0;
    var descuento = 0;

    $xml = "<DETALLE>";
    venta = "<Ventas>" +
        "<Id_Usuario>" + $("#txtIdUsuario").val() + "</Id_Usuario>" +
        "<Id_Cliente>" + $("#txtIdCliente").val() + "</Id_Cliente>" +
        "<Sub_Total>!subtotal¡</Sub_Total>" +
        "<Descuento>!descuento¡</Descuento>" +
        "<IVA>!iva¡</Iva>" +
        "<Total>!total¡</Total>" +
        "</Ventas>";
    detalleventa = "<DETALLE>"

    $('#tbVenta > tbody  > tr').each(function (index, tr) {

        var fila = tr;
        var idFarmaco = parseFloat($(fila).find("td.codigoproducto").data("idproducto"));
        var idFormapago = parseFloat($(fila).find("td.formaP").data("fp"));
        var cantidadVenta = parseFloat($(fila).find("td.catidad").data("cf"));
        var precioVenta = parseFloat($(fila).find("td.precioV").data("pv"));

        detalle = detalle + "<DETALLE>" +
            "<Id_FacturaCompra>0</Id_FacturaCompra>" +
            "<Id_Farmaco>" + idFarmaco + "</Id_Farmaco>" +
            "<Id_FormaPago>" + idFormapago + "</Id_FormaPago>" +
            "<Cantidad_Compra>" + cantidadVenta + "</Cantidad_Compra>" +
            "<Precio_Venta>" + precioVenta + "</Precio_Venta>" +
            "</DETALLE>";

        subtotal = cantidadVenta * precioVenta;
        totaldescuento = subtotal * descuento;
        IVA = subtotal * (15 / 100);
        totalcostocompra = subtotal + IVA - totaldescuento;
        subtotalFinal = subtotalFinal + subtotal;
    });

    ivaFinal = subtotalFinal * (15 / 100);
    totalFinal = subtotalFinal + ivaFinal - 0;

    console.log(subtotalFinal);
    console.log(ivaFinal);
    console.log(totalFinal);


    venta = venta.replace("!descuento¡", descuentoFinal.toString());
    venta = venta.replace("!sub_total¡", subtotalFinal.toString());
    venta = venta.replace("!iva¡", ivaFinal.toString());
    venta = venta.replace("!total¡", totalFinal.toString());
    $xml = $xml + venta + detalleventa + detalle + "</DETALLE_VENTA></DETALLE>";
    console.log($xml);
    var request = { xml: $xml };
    console.log(JSON.stringify(request));


    jQuery.ajax({
        url: $.MisUrls.url._GuardarVenta,
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
