
var tabladata;
var tablaproveedor;
var tablatienda;
var tablaproducto;


$(document).ready(function () {
    activarMenu("Compras");
    $("#txtproductocantidad").val("0");
    $("#txtfechacompra").val(ObtenerFecha());

    jQuery.ajax({
        url: $.MisUrls.url._ObtenerUsuarios,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            //USUARIO
            $("#txtIdUsuario").val(data.IdUsuario);
            $("#lblempleadonombre").text(data.Nombres);
            $("#lblempleadoapellido").text(data.Apellidos);
            $("#lblempleadocorreo").text(data.Correo);
        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
            $("#cboProveedor").LoadingOverlay("show");
        },
    });

    //OBTENER PROVEEDORES
    tablaproveedor = $('#tbProveedor').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerProveedores,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "IdProveedor", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='proveedorSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "Ruc" },
            { "data": "RazonSocial" },
            { "data": "Direccion" }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });

    //OBTENER LABORATORIO
    tablalaboratorio = $('#tbLaboratorio').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerLaboratorio,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "IdLaboratorio", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='laboratorioSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
          
            { "data": "RazonSocial" },
            { "data": "Direccion" }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });

    //OBTENER DETALLE FARMACO
    tablatienda = $('#tbDetalleFarmaco').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerDetalleFarmaco,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "IdDetalleFarmaco", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='tiendaSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "NombreComercial" },
            { "data": "Concentracion" }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });

    //OBTENER PRODUCTOS
    tablaproducto = $('#tbProducto').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerProductoStockPorTienda + "?IdDetalleFarmaco=0",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "IdProductoDetalle", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='productoSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.Codigo
                }
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.NombreGenerico
                }
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.Descripcion
                }
            },
            { "data": "Stock" }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });
})

function ObtenerFecha() {

    var d = new Date();
    var month = d.getMonth() + 1;
    var day = d.getDate();
    var output = (('' + day).length < 2 ? '0' : '') + day + '/' + (('' + month).length < 2 ? '0' : '') + month + '/' + d.getFullYear();

    return output;
}

function buscarProveedor() {
    tablaproveedor.ajax.reload();
    $('#modalProveedor').modal('show');
}

function buscarLaboratorio() {
    tablalaboratorio.ajax.reload();
    $('#modalLaboratorio').modal('show');
}

function buscarDetalleFarmaco() {
    tablatienda.ajax.reload();
    $('#modalDetalleFarmaco').modal('show');
}


$('#btnBuscarProducto').on('click', function () {

    if (parseInt($("#txtIdDetalleFarmaco").val()) == 0) {
        swal("Mensaje", "Debe seleccionar un Producto Primero", "warning")
        return;
    }
    tablaproducto.ajax.url($.MisUrls.url._ObtenerProductoStockPorTienda + "?IdDetalleFarmaco=" + parseInt($("#txtIdDetalleFarmaco").val())).load();

    $('#modalProducto').modal('show');
})


function proveedorSelect(json) {

    $("#txtIdProveedor").val(json.IdProveedor);
    $("#txtRucProveedor").val(json.Ruc);
    $("#txtRazonSocialProveedor").val(json.RazonSocial);

    $('#modalProveedor').modal('hide');
}

function laboratorioSelect(json) {

    $("#txtIdLaboratorio").val(json.IdLaboratorio);
    $("#txtRazonSocialLaboratorio").val(json.RazonSocial);

    $('#modalLaboratorio').modal('hide');
}

function tiendaSelect(json) {
    $("#txtIdDetalleFarmaco").val(json.IdDetalleFarmaco);
    $("#txtNombreComercial").val(json.NombreComercial);
    $("#txtConcentracion").val(json.Concentracion);

    $('#modalDetalleFarmaco').modal('hide');
}

function productoSelect(json) {
    $("#txtIdProducto").val(json.oProducto.IdProducto);
    $("#txtCodigoProducto").val(json.oProducto.Codigo);
    $("#txtNombreProducto").val(json.oProducto.NombreGenerico);

    $('#modalProducto').modal('hide');
}



$("#txtproductocodigo").on('keypress', function (e) {


    if (e.which == 13) {

        var request = { IdDetalleFarmaco: parseInt($("#txtIdDetalleFarmaco").val()) }


        //OBTENER PROVEEDORES
        jQuery.ajax({
            url: $.MisUrls.url._ObtenerProductoStockPorTienda + "?IdDetalleFarmaco=" + parseInt($("#txtIdDetalleFarmaco").val()),
            type: "GET",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                var encontrado = false;
                if (data.data != null) {
                    $.each(data.data, function (i, item) {
                        if (item.oProducto.Codigo == $("#txtproductocodigo").val()) {

                            $("#txtIdProducto").val(item.oProducto.IdProducto);
                            $("#txtCodigoProducto").val(oProducto.Codigo);
                            $("#txtNombreProducto").val(oProducto.NombreGenerico);
                            encontrado = true;
                            return false;
                        }
                    })

                    if (!encontrado) {

                        $("#txtIdProducto").val("0");
                        $("#txtCodigoProducto").val("0");
                        $("#txtNombreProducto").val("");

                    }
                }

            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {
                $("#cboProveedor").LoadingOverlay("show");
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

$("#txtCantidadProducto").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});

$("#txtPrecioCompraProducto").inputFilter(function (value) {
    return /^-?\d*[.]?\d{0,2}$/.test(value);
});

$("#txtPrecioVentaProducto").inputFilter(function (value) {
    return /^-?\d*[.]?\d{0,2}$/.test(value);
});



$('#btnAgregarCompra').on('click', function () {

    var existe_codigo = false;
    if (
        parseInt($("#txtIdProveedor").val()) == 0 ||
        parseInt($("#txtIdLaboratorio").val()) == 0 ||
        parseInt($("#txtIdDetalleFarmaco").val()) == 0 ||
        parseInt($("#txtIdProducto").val()) == 0 ||
        parseFloat($("#txtCantidadProducto").val()) == 0 ||
        parseFloat($("#txtPrecioCompraProducto").val()) == 0 ||
        parseFloat($("#txtPrecioVentaProducto").val()) == 0
    ) {
        swal("Mensaje", "Debe completar todos los campos", "warning")
        return;
    }

    $('#tbCompra > tbody  > tr').each(function (index, tr) {
        var fila = tr;
        var codigoproducto = $(fila).find("td.codigoproducto").text();

        if (codigoproducto == $("#txtCodigoProducto").val()) {
            existe_codigo = true;
            return false;
        }

    });

    if (!existe_codigo) {
        $("<tr>").append(
            $("<td>").append(
                $("<button>").addClass("btn btn-danger btn-sm").text("Eliminar")
            ),
            $("<td>").addClass("codigoproducto").data("idproducto", $("#txtIdProducto").val()).append($("#txtCodigoProducto").val()),
            $("<td>").append($("#txtNombreProducto").val()),
            $("<td>").append($("#txtNombreComercial").val()),
            $("<td>").append($("#txtRucProveedor").val()),
            $("<td>").append($("#txtRazonSocialLaboratorio").val()),
            $("<td>").addClass("cantidad").append($("#txtCantidadProducto").val()),
            $("<td>").addClass("preciocompra").append($("#txtPrecioCompraProducto").val()),
            $("<td>").addClass("precioventa").append($("#txtPrecioVentaProducto").val()),
        ).appendTo("#tbCompra tbody");

        $("#txtIdProducto").val("0");
        $("#txtCodigoProducto").val("");
        $("#txtNombreProducto").val("");
        $("#txtCantidadProducto").val("0");
        $("#txtPrecioCompraProducto").val("0");
        $("#txtPrecioVentaProducto").val("0");

    } else {
        swal("Mensaje", "El producto ya existe en la compra", "warning")
    }
})

$('#tbCompra tbody').on('click', 'button[class="btn btn-danger btn-sm"]', function () {
    $(this).parents("tr").remove();
})



$('#btnTerminarGuardarCompra').on('click', function () {


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
        "<IdUsuario>!idusuario¡</IdUsuario>" +
        "<IdProveedor>" + $("#txtIdProveedor").val() + "</IdProveedor>" +
        "<IdLaboratorio>" + $("#txtIdLaboratorio").val() + "</IdLaboratorio>" +
        "<IdDetalleFarmaco>" + $("#txtIdDetalleFarmaco").val() + "</IdDetalleFarmaco>" +
        "<TotalCosto>!totalcosto¡</TotalCosto>" +
        "</COMPRA>";
    detallecompra = "<DETALLE_COMPRA>"

    $('#tbCompra > tbody  > tr').each(function (index, tr) {

        var fila = tr;
        var idproducto = parseFloat($(fila).find("td.codigoproducto").data("idproducto"));
        var cantidad = parseFloat($(fila).find("td.cantidad").text());
        var preciocompra = parseFloat($(fila).find("td.preciocompra").text());
        var precioventa = parseFloat($(fila).find("td.precioventa").text());
        var totalcosto = parseFloat(cantidad) * parseFloat(preciocompra);

        detalle = detalle + "<DETALLE>" +
            "<IdCompra>0</IdCompra>" +
            "<IdProducto>" + idproducto + "</IdProducto>" +
            "<Cantidad>" + cantidad + "</Cantidad>" +
            "<PrecioCompra>" + preciocompra + "</PrecioCompra>" +
            "<PrecioVenta>" + precioventa + "</PrecioVenta>" +
            "<TotalCosto>" + totalcosto.toString() + "</TotalCosto>" +
            //"<IdFarmaceutica>" +  + "<IdFarmaceutica>" +
            "</DETALLE>";
        totalcostocompra = totalcostocompra + totalcosto;

    });

    compra = compra.replace("!totalcosto¡", totalcostocompra.toString());
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
                $("#txtRucProveedor").val("");
                $("#txtRazonSocialProveedor").val("");

                //Laboratorio
                $("#txtIdLaboratorio").val("0");
                $("#txtRazonSocialLaboratorio").val("");

                ////DETALLE FARMACO
                //$("#txtIdDetalleFarmaco").val("0");
                //$("#txtNombreComercial").val("");

                //DETALLE FARMACO
                $("#txtIdFormaFarmaceutica").val("0");
                $("#txtFormaFarmaceutica").val("0");
                $("#txtDescripcion").val("");

                //PRODUCTO
                $("#txtIdProducto").val("0");
                $("#txtCodigoProducto").val("");
                $("#txtNombreProducto").val("");
                $("#txtCantidadProducto").val("0");
                $("#txtPrecioCompraProducto").val("0");
                $("#txtPrecioVentaProducto").val("0");

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
