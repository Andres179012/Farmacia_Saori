﻿
var tabladata;
$(document).ready(function () {
    activarMenu("Mantenedor");


    ////validamos el formulario
    $("#form").validate({
        rules: {
            Descripcion: "required"
        },
        messages: {
            Descripcion: "(*)"
        },
        errorElement: 'span'
    });

    tabladata = $('#tbdata').DataTable({
        "ajax": {
            "url": $.MisUrls.url._ObtenerRoles,
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "Descripcion" },
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
                "data": "IdRol", "render": function (data, type, row, meta) {
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

        $("#txtid").val(json.IdRol);

        $("#txtDescripcion").val(json.Descripcion);

        var valor = 0;
        valor = json.Activo == true ? 1 : 0
        $("#cboEstado").val(valor);

    } else {
        $("#txtDescripcion").val("");
        $("#cboEstado").val(1);
    }

    $('#FormModal').modal('show');

}


function Guardar() {

    if ($("#form").valid()) {

        var request = {
            objeto: {
                IdRol: $("#txtid").val(),
                Descripcion: $("#txtDescripcion").val(),
                Activo: parseInt($("#cboEstado").val()) == 1 ? true : false
            }
        }

        jQuery.ajax({
            url: $.MisUrls.url._GuardarRol,
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
        text: "¿Desea eliminar el rol seleccionado?",
        type: "warning",
        showCancelButton: true,

        confirmButtonText: "Si",
        confirmButtonColor: "#DD6B55",

        cancelButtonText: "No",

        closeOnConfirm: true
    },

        function () {
            jQuery.ajax({
                url: $.MisUrls.url._EliminarRol + "?id=" + $id,
                type: "GET",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data.resultado) {
                        tabladata.ajax.reload();
                    } else {
                        swal("Mensaje", "No se pudo eliminar el rol", "warning")
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