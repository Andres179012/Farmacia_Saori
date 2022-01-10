
var tabladata;


$(document).ready(function () {
    //OBTENER PROVEEDORES
    tabladata = $('#tbDetalleFarmaco').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerDetalleCompra,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            
            {
                "data": "IdDetalleCompra", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='compraSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "FechaRegistro" },
            {
                "data": "oUsuario", render: function (data) {
                    return data.IdUsuario
                }
            },
            {
                "data": "oUsuario", render: function (data) {
                    return data.Correo
                }
            },
            { "data": "IdCompra" },
            { "data": "NumeroCompra" },
            {
                "data": "oProveedor", render: function (data) {
                    return data.IdProveedor
                }
            },
            {
                "data": "oProveedor", render: function (data) {
                    return data.RazonSocial
                }
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.IdProducto  
                }
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.NombreGenerico
                }
            },
            {
                "data": "oDetalleFarmaco", render: function (data) {
                    return data.IdDetalleFarmaco
                }
            },
            {
                "data": "oDetalleFarmaco", render: function (data) {
                    return data.NombreComercial
                }
            },
            {
                "data": "oLaboratorio", render: function (data) {
                    return data.NombreLaboratorio
                }
            },
           {
                "data": "oDetalleFarmaco", render: function (data) {
                    return data.Concentracion
                }
            },
            { "data": "Cantidad" },
            { "data": "PrecioCompra" },
            { "data": "PrecioVenta" },
            { "data": "TotalCosto" },

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });
})


function buscarDetalleCompra() {
    tabladata.ajax.reload();
    $('#modalCompra').modal('show');
}

function compraSelect(json) {

    $("#txtidCompra").val(json.IdCompra);
    $("#txtidproveedor").val(json.IdProveedor);
    $("#txtidusuario").val(json.IdUsuario);
    $("#txtidproducto").val(json.IdProducto);
    $("#txtiddetalleproducto").val(json.IdDetalleFarmaco);
    $("#txtcodigocompra").val(json.NumeroCompra);
    $("#txtproveedor").val(json.oProveedor.RazonSocial);
    $("#txtfechacompra").val(json.FechaRegistro);
    $("#txtusuario").val(json.oUsuario.Correo);
    $("#txtnombregenerico").val(json.oProducto.NombreGenerico);
    $("#txtnombrecomercial").val(json.oDetalleFarmaco.NombreComercial);
    $("#txtconcentracion").val(json.oDetalleFarmaco.Concentracion);
    $("#txtlaboratorio").val(json.oLaboratorio.NombreLaboratorio);
    $("#txtcantidad").val(json.Cantidad);
    $("#txtpreciocompra").val(json.PrecioCompra);
    $("#txttotalcosto").val(json.TotalCosto);

    $('#modalCompra').modal('hide');
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


$("#txtcantidaddevolucion").inputFilter(function (value) {
    return /^-?\d*$/.test(value);
});

$("#txtconcepto").inputFilter(function (value) {
    return (value);
});

$('#tbDevolucion tbody').on('click', 'button[class="btn btn-danger btn-sm"]', function () {
    $(this).parents("tr").remove();
})

function Guardar() {

   

        var request = {
            objeto: {
                IdCompra: parseInt($("#txtidCompra").val()),
                IdProveedor: $("#txtidproveedor").val(),
                IdDetalleFarmaco: $("#txtiddetalleproducto").val(),
                IdUsuario: $("#txtidusuario").val(),
                IdProducto: $("#txtidproducto").val(),
                Concepto: $("#txtconcepto").val(),
                Cantidad: $("#txtcantidaddevolucion").val()
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._RegistrarDevolucion,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();

                    swal("Mensaje", "Se registro la compra", "success")
                } else {

                    swal("Mensaje", "No se pudo guardar los cambios", "warning")
                }
            },
            error: function (error) {
                console.log(error)
            },
            beforeSend: function () {

            },
        });

}