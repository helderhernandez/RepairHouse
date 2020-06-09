function stylesCRUD() {
    //input Create (en vista crear)
    var inputCreate = $("input[value='Create']")[0];
    $(inputCreate).val("Crear");
    $(inputCreate).attr("title", "Crear");
    $(inputCreate).addClass("btn btn-success");

    //input Save (en vista editar)
    var inputSave = $("input[value='Save']")[0];
    $(inputSave).val("Guardar");
    $(inputSave).attr("title", "Guardar");
    $(inputSave).addClass("btn btn-success");

    //input Edit (en vista details)
    var inputSave = $("p a:contains(Edit)")[0];
    $(inputSave).text("Editar");
    $(inputSave).attr("title", "Editar");
    $(inputSave).addClass("btn btn-primary");

    //input Delete
    var inputDelete = $("input[value='Delete']")[0];
    $(inputDelete).val("Eliminar");
    $(inputDelete).attr("title", "Eliminar");
    $(inputDelete).addClass("btn btn-danger");

    $("div a:contains(Back to List)").each(function () {
        var regresarLink = $(this)[0];
        $(regresarLink).text("Regresar");
        $(regresarLink).attr("title", "Regresar");
        $(regresarLink).addClass("btn btn-dark")
        $(regresarLink).prepend('<span style="margin-right: 10px"><i class="fa fa-arrow-left"></i></span>');

    })

    $("p a:contains(Back to List)").each(function () {
        var regresarLink = $(this)[0];
        $(regresarLink).text("Regresar");
        $(regresarLink).attr("title", "Regresar");
        $(regresarLink).addClass("btn btn-dark")
        $(regresarLink).prepend('<span style="margin-right: 10px"><i class="fa fa-arrow-left"></i></span>');

    })
}

function stylesForms() {
    var form = $("form > div.form-horizontal")[0];
    $(form).addClass("col-sm-12 col-md-10 col-lg-8 m-auto");
}

function stylesInputsReadonlyValidate() {
    // para los input que no se pueden editar y que se tiene que validar que este lleno
    $(".app-readonly").attr("tabindex", -1);
    $(".app-readonly").css("background-color", "#e9ecef");
    $(".app-readonly").keydown(function () {
        return false;
    });
}

$(document).ready(function () {
    stylesCRUD();
    stylesForms();
    stylesInputsReadonlyValidate();
});