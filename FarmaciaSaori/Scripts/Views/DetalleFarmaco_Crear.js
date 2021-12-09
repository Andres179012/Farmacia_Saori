
var tabladata;
$(document).ready(function () {
    activarMenu("DetalleFarmaco");


    ////validamos el formulario
    $("#form").validate({
        rules: {
            NombreComercial: "required"
        },
        messages: {
            NombreComercial: "(*)"

        },
        errorElement: 'span'
    });

    //OBTENER PRODUCTO
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerProductos,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#txtProducto").html("");

            if (data.data != null) {
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdProducto }).text(item.NombreGenerico).appendTo("#txtProducto");
                    }
                })
                $("#txtProducto").val($("#txtProducto option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
    //OBTENER FORMA FARMACEUTICA
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerFormaFarmaceutica,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#txtForma").html("");

            if (data.data != null) {
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdFormaFarmaceutica }).text(item.FormaFarmaceutica).appendTo("#txtForma");
                    }
                })
                $("#txtForma").val($("#txtForma option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
    //OBTENER VIA ADMINISTRACION
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerViaAdministracion,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#txtVia").html("");

            if (data.data != null) {
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdViaAdministracion }).text(item.ViaAdministracion).appendTo("#txtVia");
                    }
                })
                $("#txtVia").val($("#txtVia option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
    //OBTENER Laboratorio
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerLaboratorio,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#txtLaboratorio").html("");

            if (data.data != null) {
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdLaboratorio }).text(item.NombreLaboratorio).appendTo("#txtLaboratorio");
                    }
                })
                $("#txtLaboratorio").val($("#txtLaboratorio option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });
    //OBTENER PROVEEDOR
    jQuery.ajax({
        url: $.MisUrls.url._ObtenerProveedores,
        type: "GET",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (data) {

            $("#txtProveedor").html("");

            if (data.data != null) {
                $.each(data.data, function (i, item) {

                    if (item.Activo == true) {
                        $("<option>").attr({ "value": item.IdProveedor }).text(item.RazonSocial).appendTo("#txtProveedor");
                    }
                })
                $("#txtProveedor").val($("#txtProveedor option:first").val());
            }

        },
        error: function (error) {
            console.log(error)
        },
        beforeSend: function () {
        },
    });

    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerDetalleFarmaco,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "oProducto", render: function (data) {
                    return data.NombreGenerico
                }
            },
            {
                "data": "oFormaFarmaceutica", render: function (data) {
                    return data.FormaFarmaceutica
                }
            },
            {
                "data": "oViaAdministracion", render: function (data) {
                    return data.ViaAdministracion
                }
            },
            {
                "data": "oProveedor", render: function (data) {
                    return data.RazonSocial
                }
            },
            { "data": "NombreComercial" },
            { "data": "Concentracion" },
            { "data": "PrecioCompra" },
            { "data": "PrecioVenta" },
            
            {
                "data": "PrescripcionMedica", "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success">Si</span>'
                    } else {
                        return '<span class="badge badge-danger">No </span>'
                    }
                }
            },
            { "data": "Stock" },
            {
                "data": "Iniciado", "render": function (data) {
                    if (data) {
                        return '<span class="badge badge-success">Si</span>'
                    } else {
                        return '<span class="badge badge-danger">No </span>'
                    }
                }
            },
            {
                "data": "IdDetalleFarmaco", "render": function (data, type, row, meta) {
                    return "<button class='btn btn-primary btn-sm' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='fas fa-pen'></i></button>" +
                        "<button class='btn btn-danger btn-sm ml-2' type='button' onclick='eliminar(" + data + ")'><i class='fa fa-trash'></i></button>"
                },
                "orderable": false,
                "searchable": false,
                "width": "90px"
            }

        ],
        "language": {
            "url": $.MisUrls.url.Url_datatable_spanish
        },
        responsive: true
    });


})


function abrirPopUpForm(json) {

    $("#txtid").val(0);

    if (json != null) {

        $("#txtid").val(json.IdDetalleFarmaco);

        $("#txtProducto").val(json.IdProducto);
        $("#txtForma").val(json.IdFormaFarmaceutica);
        $("#txtVia").val(json.IdViaAdministracion);
        $("#txtLaboratorio").val(json.IdLaboratorio);
        $("#txtProveedor").val(json.IdProveedor);
        $("#txtNombreComercial").val(json.NombreComercial);
        $("#txtConcentracion").val(json.Concentracion);
        $("#txtFechaVencimiento").val(json.FechaVencimiento);
        $("#txtPrecioVenta").val(json.PrecioVenta);
        $("#txtPrecioCompra").val(json.PrecioCompra);
        $("#txtNumero").val(json.NumeroLote);
        $("#cboEstado").val(json.PrescripcionMedica == true ? 1 : 0);

    } else {

        $("#txtProducto").val("");
        $("#txtForma").val("");
        $("#txtLaboratorio").val("");
        $("#txtVia").val("");
        $("#txtProveedor").val("");
        $("#txtNombreComercial").val("");
        $("#txtConcentracion").val("");
        $("#txtFechaVencimiento").val("");
        $("#txtPrecioVenta").val("");
        $("#txtPrecioCompra").val("");
        $("#txtNumero").val("");
        $("#cboEstado").val(1);

    }

    $('#FormModal').modal('show');

}


function Guardar() {

    if ($("#form").valid()) {

        var request = {
            objeto: {
                IdDetalleFarmaco: parseInt($("#txtid").val()),
                IdProducto: $("#txtProducto").val(),
                IdFormaFarmaceutica: $("#txtForma").val(),
                IdViaAdministracion: $("#txtVia").val(),
                IdLaboratorio: $("#txtLaboratorio").val(),
                IdProveedor: $("#txtProveedor").val(),
                NombreComercial: $("#txtNombreComercial").val(),
                Concentracion: $("#txtConcentracion").val(),
                FechaVencimiento: $("#txtFechaVencimiento").val(),
                PrecioVenta: $("#txtPrecioVenta").val(),
                PrecioCompra: $("#txtPrecioCompra").val(),
                NumeroLote:$("#txtNumero").val(),
                PrescripcionMedica: ($("#cboEstado").val() == "1" ? true : false)
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._GuardarDetalleFarmaco,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                    $('#FormModal').modal('hide');
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

}


function eliminar($id) {



    swal({
        title: "Mensaje",
        text: "¿Desea eliminar el cliente seleccionado?",
        type: "warning",
        showCancelButton: true,

        confirmButtonText: "Si",
        confirmButtonColor: "#DD6B55",

        cancelButtonText: "No",

        closeOnConfirm: true
    },

        function () {
            jQuery.ajax({
                url: $.MisUrls.url._EliminarDetalleFarmaco + "?id=" + $id,
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        tabladata.ajax.reload();
                    } else {
                        swal("Mensaje", "No se pudo eliminar el cliente", "warning")
                    }
                },
                error: function (error) {
                    console.log(error)
                },
                beforeSend: function () {

                },
            });
        });

}