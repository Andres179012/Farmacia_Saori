
var tabladata;


$(document).ready(function () {
    //OBTENER PROVEEDORES
    tabladata = $('#tbDetalleFarmaco').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerDetalleVenta,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            {
                "data": "IdDetalleVenta", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-sm btn-primary ml-2' type='button' onclick='compraSelect(" + JSON.stringify(row) + ")'><i class='fas fa-check'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            },
            { "data": "FechaRegistro" },
            {
                "data": "oUsuario", render: function (data) {
                    return data.Correo
                }
            },
            { "data": "NumeroVenta" },
            {
                "data": "oCliente", render: function (data) {
                    return data.Nombre
                }
            },
            {
                "data": "oProducto", render: function (data) {
                    return data.NombreGenerico
                }
            },
            {
                "data": "oDetalleFarmaco", render: function (data) {
                    return data.NombreComercial
                }
            },
            {
                "data": "oDetalleFarmaco", render: function (data) {
                    return data.Concentracion
                }
            },
            { "data": "Cantidad" },
            { "data": "PrecioUnidad" },
            { "data": "ImporteTotal" },

            //{
            //    "data": "oUsuario", render: function (data) {
            //        return data.IdUsuario
            //    }
            //},
            //{ "data": "IdVenta" },
            //{
            //    "data": "oCliente", render: function (data) {
            //        return data.IdCliente
            //    }
            //},
            //{
            //    "data": "oProducto", render: function (data) {
            //        return data.IdProducto
            //    }
            //},
            //{
            //    "data": "oDetalleFarmaco", render: function (data) {
            //        return data.IdDetalleFarmaco
            //    }
            //},
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

    $("#txtidventa").val(json.IdVenta);
    $("#txtidcliente").val(json.IdCliente);
    $("#txtidusuario").val(json.IdUsuario);
    $("#txtidproducto").val(json.IdProducto);
    $("#txtiddetalleproducto").val(json.IdDetalleFarmaco);
    $("#txtcodigoventa").val(json.NumeroVenta);
    $("#txtcliente").val(json.oCliente.Nombre);
    $("#txtfechaventa").val(json.FechaRegistro);
    $("#txtusuario").val(json.oUsuario.Correo);
    $("#txtnombregenerico").val(json.oProducto.NombreGenerico);
    $("#txtnombrecomercial").val(json.oDetalleFarmaco.NombreComercial);
    $("#txtconcentracion").val(json.oDetalleFarmaco.Concentracion);
    $("#txtcantidad").val(json.Cantidad);
    $("#txtprecioventa").val(json.PrecioUnidad);
    $("#txttotalcosto").val(json.ImporteTotal);

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
            IdVenta: parseInt($("#txtidventa").val()),
            IdCliente: $("#txtidcliente").val(),
            IdDetalleFarmaco: $("#txtiddetalleproducto").val(),
            IdUsuario: $("#txtidusuario").val(),
            IdProducto: $("#txtidproducto").val(),
            Concepto: $("#txtconcepto").val(),
            Cantidad: $("#txtcantidaddevolucion").val()
        }
    }

    jQuery.ajax({
        url: $.MisUrls.url._RegistrarDevolucionV,
        type: "POST",
        data: JSON.stringify(request),
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            if (data.resultado) {
                tabladata.ajax.reload();

                swal("Mensaje", "Se registro la Devolucion", "success")
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