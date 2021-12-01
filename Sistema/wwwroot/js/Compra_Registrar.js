
var tabladata;
var tablaproveedor;
var tablalaboratorio;
var tablaformaf;
var tablaformap;
var tablaproducto;


$(document).ready(function () {
    activarMenu("Compras");

    //OBTENER PROVEEDORES
    tablaproveedor = $('#tbProveedor').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerProveedores,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_Proveedor", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarproveedor(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "proveedor" },
            { "data": "direccion" },
            { "data": "telefono" }

        ],
        responsive: true
    });
    //OBTENER LABORATORIOS
    tablalaboratorio = $('#tbLaboratorio').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerLaboratorios,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_Laboratorio", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarlaboratorio(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "nombre_Laboratorio" }
        ],
        responsive: true
    });
    //OBTENER FORMA FARMACEUTICA
    tablaformaf = $('#tbFormaFarmaceutica').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerFormaFarmaceutica,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "id_FormaFarmaceutica", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='buscarformaf(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "forma_Farmaceutica" }
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

function buscarproveedor(json){
    $("#txtIdProveedor").val(0);

    if (json != null) {

        $("#txtIdProveedor").val(json.id_Proveedor);
        $("#txtNombre").val(json.proveedor);
        $("#txtDireccion").val(json.direccion);
        $("#txtTelefono").val(json.telefono);

    } else {
        $("#txtNombre").val("");
        $("#txtDireccion").val("");
        $("#txtTelefono").val("");
    }

    $('#modalProveedor').modal('show');
}


function buscarlaboratorio(json) {
    $("#txtLab").val(0);

    if (json != null) {

        $("#txtLab").val(json.id_Laboratorio);
        $("#txtLaboratorio").val(json.nombre_Laboratorio);

    } else {
        $("#txtLaboratorio").val("");

    }

    $('#modalLaboratorio').modal('show'); 
}

function buscarformaf(json) {
    $("#txtformaf").val(0);

    if (json != null) {

        $("#txtformaf").val(json.id_FormaFarmaceutica);
        $("#txtformafar").val(json.forma_Farmaceutica);
        
    } else {
        $("#txtformafar").val("");

    }

    $('#modalFormaFarmaceutica').modal('show');
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
    console.log($('#txtIdProducto').val());
}



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

$("#txtPrecioCompraFarmaco").inputFilter(function (value) {
    return /^-?\d*[.]?\d{0,2}$/.test(value);
});


$('#btnAgregarCompra').on('click', function () {

    var existe_codigo = false;
    if (
        parseInt($("#txtNombre").val()) == 0 ||
        parseInt($("#txtLaboratorio").val()) == 0 ||
        parseInt($("#txtformafar").val()) == 0 ||
        parseInt($("#txtformapago").val()) == 0 ||
        parseInt($("#txtNombreFarmaco").val()) == 0 ||
        parseFloat($("#txtCantidadFarmaco").val()) == 0 ||
        parseFloat($("#txtPrecioCompraFarmaco").val()) == 0 
    ) {
        swal("Mensaje", "Debe completar todos los campos", "warning")
        return;
    }

    $('#tbCompra > tbody  > tr').each(function (index, tr) {
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
            $("<td>").addClass("proveedor").data("prov", $("#txtIdProveedor").val()).append($("#txtNombre").val()),
            $("<td>").addClass("lab").data("idlab", $("#txtLab").val()).append($("#txtLaboratorio").val()),
            $("<td>").addClass("formaf").data("ff", $("#txtformaf").val()).append($("#txtformafar").val()),
            $("<td>").addClass("formap").data("fp", $("#txtformap").val()).append($("#txtformapago").val()),
            $("<td>").addClass("nombreF").data("nombrF", $("#txtNombreFarmaco").val()).append($("#txtNombreFarmaco").val()),
            $("<td>").addClass("cantidad").data("cant", $("#txtCantidadFarmaco").val()).append($("#txtCantidadFarmaco").val()),
            $("<td>").addClass("preciocompra").data("precio", $("#txtPrecioCompraFarmaco").val()).append($("#txtPrecioCompraFarmaco").val()),




            //$("<td>").append($("#txtNombre").val()),
            //$("<td>").append($("#txtLaboratorio").val()),
            //$("<td>").append($("#txtformafar").val()),
            //$("<td>").append($("#txtformapago").val()),
            //$("<td>").append($("#txtNombreFarmaco").val()),
            //$("<td>").addClass("#cantidad").append($("#txtCantidadFarmaco").val()),
            //$("<td>").addClass("#preciocompra").append($("#txtPrecioCompraFarmaco").val()),
        ).appendTo("#tbCompra tbody");

        $("#txtIdProducto").val("0");
        $("#txtNombreFarmaco").val("");
        $("#txtCantidadFarmaco").val("0");
        $("#txtPrecioCompraFarmaco").val("0");

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
    
    var subtotalFinal = 0.0;
    var ivaFinal = 0.0;
    var totalFinal = 0.0;
    var descuentoFinal = 0;

    $xml = "<DETALLE>";
    compra = "<COMPRA>" +
        "<Id_Proveedor>" + $("#txtIdProveedor").val() + "</Id_Proveedor>" +
        "<Id_Laboratorio>" + $("#txtLab").val() + "</Id_Laboratorio>" +
      //  "<Id_Producto>" + $("#txtIdProducto").val() + "</Id_Producto>" +
        "<Sub_Total>!sub_total¡</Sub_Total>" +
        "<Descuento>!descuento¡</Descuento>" +
        "<IVA>!iva¡</Iva>" +
        "<Total>!total¡</Total>" +
        "</COMPRA>";
    detallecompra = "<DETALLE_COMPRA>"

    $('#tbCompra > tbody  > tr').each(function (index, tr) {

        var fila = tr;
        var idFarmaco = parseFloat($(fila).find("td.codigoproducto").data("idproducto"));
        var idFormafarmaceutica = parseFloat($(fila).find("td.formaf").data("ff"));
        var idFormapago = parseFloat($(fila).find("td.formap").data("fp"));
        var cantidad = parseFloat($(fila).find("td.cantidad").data("cant"));
        var preciocompra = parseFloat($(fila).find("td.preciocompra").data("precio"));
        var descuento = 0;
       // var descuento = parseFloat($(fila).find("td.descuento").text());
        var lote = 0;
        var unitario = 0;

        detalle = detalle + "<DETALLE>" +
            "<Id_FacturaCompra>0</Id_FacturaCompra>" +
           "<Id_Farmaco>" + idFarmaco + "</Id_Farmaco>" +
            "<Id_FormaPago>" + idFormapago + "</Id_FormaPago>" +
            "<Cantidad_Compra>" + cantidad + "</Cantidad_Compra>" +
            "<Precio_Compra>" + preciocompra + "</Precio_Compra>" +
            "<Descuento>" + descuento + "</Descuento>" +
            "<Id_FormaFarmaceutica>"+idFormafarmaceutica +"</Id_FormaFarmaceutica>" +
           
            "<Lote>" + lote + "</Lote>" +
            "<Unitario>" + unitario+ "</Unitario>" +
            "</DETALLE>";

        sub_total = cantidad * preciocompra;
        totaldescuento = sub_total * descuento;
        IVA = sub_total * (15 / 100);
        totalcostocompra = sub_total + IVA - totaldescuento;
        subtotalFinal = subtotalFinal + sub_total;

    });
    ivaFinal = subtotalFinal * (15 / 100);
    totalFinal = subtotalFinal + ivaFinal - 0;

    console.log(subtotalFinal);
    console.log(ivaFinal);
    console.log(totalFinal);


    compra = compra.replace("!descuento¡", descuentoFinal.toString());
    compra = compra.replace("!sub_total¡", subtotalFinal.toString());
    compra = compra.replace("!iva¡", ivaFinal.toString());
    compra = compra.replace("!total¡", totalFinal.toString());
    $xml = $xml + compra + detallecompra + detalle + "</DETALLE_COMPRA></DETALLE>";
    console.log($xml);
    var request = { xml: $xml };
    var d = JSON.stringify(request);
    console.log(JSON.stringify(request));


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
                $("#txtIdProducto").val("");
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
