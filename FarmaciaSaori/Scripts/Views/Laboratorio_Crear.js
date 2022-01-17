
var tabladata;
$(document).ready(function () {
    activarMenu("Laboratorio");


    ////validamos el formulario
    $("#form").validate({
        rules: {
            nombrelaboratorio: "required",
            razonsocial: "required",
            direccion: "required",
            telefono: "required"
        },
        messages: {
            nombrelaboratorio: "(*)",
            razonsocial: "(*)",
            direccion: "(*)",
            telefono: "(*)"
        },
        errorElement: 'span'
    });


    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerLaboratorio,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "NombreLaboratorio" },
            { "data": "RUC" },
            { "data": "RazonSocial" },
            { "data": "Telefono" },
            { "data": "Correo" },
            { "data": "Direccion" },
            { "data": "PoliticaVencimiento" },
            { "data": "CantidadMeses" },
            {
                "data": "Activo", "render": function (data) {
                    if (data) {
                        return '<span class="badge bg-light-success text-success w-100">Activo</span>'
                    } else {
                        return '<span class="badge bg-light-danger text-danger w-100">Inactivo</span>'
                    }
                }
            },
            {
                "data": "IdLaboratorio", "render": function (data, type, row, meta) {
                    return "<button class='text-primary bg - light - primary border - 0' type='button' onclick='abrirPopUpForm(" + JSON.stringify(row) + ")'><i class='bx bxs-edit'></i></button>" +
                        "<button class='ms-4 text-danger bg-light-danger border-0' type='button' onclick='eliminar(" + data + ")'><i class='bx bxs-trash'></i></button>"
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

        $("#txtid").val(json.IdLaboratorio);


        $("#txtNombreLaboratorio").val(json.NombreLaboratorio);
        $("#txtRUC").val(json.RUC);
        $("#txtRazonSocial").val(json.RazonSocial);
        $("#txtTelefono").val(json.Telefono);
        $("#txtCorreo").val(json.Correo);
        $("#txtDireccion").val(json.Direccion);
        $("#txtPoliticaVencimiento").val(json.PoliticaVencimiento);
        $("#txtCantidadMeses").val(json.CantidadMeses);
        $("#cboEstado").val(json.Activo == true ? 1 : 0);

    } else {
        $("#txtNombreLaboratorio").val("");
        $("#txtRUC").val("");
        $("#txtRazonSocial").val("");
        $("#txtTelefono").val("");
        $("#txtCorreo").val("");
        $("#txtDireccion").val("");
        $("#txtPoliticaVencimiento").val("");
        $("#txtCantidadMeses").val("");
        $("#cboEstado").val(1);

    }

    $('#FormModal').modal('show');

}


function Guardar() {

    if ($("#form").valid()) {

        var request = {
            objeto: {
                IdLaboratorio: $("#txtid").val(),
                NombreLaboratorio: $("#txtNombreLaboratorio").val(),
                RUC: $("#txtRUC").val(),
                RazonSocial: $("#txtRazonSocial").val(),
                Telefono: $("#txtTelefono").val(),
                Correo: $("#txtCorreo").val(),
                Direccion: $("#txtDireccion").val(),
                PoliticaVencimiento: $("#txtPoliticaVencimiento").val(),
                CantidadMeses: $("#txtCantidadMeses").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._GuardarLaboratorio,
            type: "POST",
            data: JSON.stringify(request),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            success: function (data) {

                if (data.resultado) {
                    tabladata.ajax.reload();
                    $('#FormModal').modal('hide');
                    swal("Mensaje", "Se registro el laboratorio", "success")
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
                url: $.MisUrls.url._EliminarLaboratorio + "?id=" + $id,
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