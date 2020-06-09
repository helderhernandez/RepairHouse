function stylesTables() {
    // tabla principal
    var tablePrincipal = $("table[class='table']")[0];
    $(tablePrincipal).addClass("table-striped table-bordered table-dark table-responsive-md"); // agregamos estilos boostrap
};

function stylesActionLinksTables() {
    // iconos edit
    $("td a:contains(Edit)").each(function () {
        var editLink = $(this)[0];
        $(editLink).text("");
        $(editLink).attr("title", "Editar");
        $(editLink).append('<button class="btn btn-primary"><i class="fa fa-pencil"></i></button>'); 
    })

    // iconos details
    $("td a:contains(Details)").each(function () {
        var detailsLink = $(this)[0];
        $(detailsLink).text("");
        $(detailsLink).attr("title", "Detalle");
        $(detailsLink).append('<button class="btn btn-secondary"><i class="fa fa-eye"></i></button>'); 
    })


    // iconos delete
    $("td a:contains(Delete)").each(function () {
        var deleteLink = $(this)[0];
        $(deleteLink).text("");
        $(deleteLink).attr("title", "Eliminar");
        $(deleteLink).append('<button class="btn btn-danger"><i class="fa fa-trash"></i></button>');
    })
};

function stylesCreateLink() {
    // enlace crear nuevo
    $("p a:contains(Create New)").each(function () {
        var createLink = $(this)[0];
        $(createLink).text("Crear Nuevo");
        $(createLink).attr("title", "Crear Nuevo");
        $(createLink).addClass("btn btn-success")
        $(createLink).append('<span style="margin-left: 10px"><i class="fa fa-plus"></i></span>');
    })
};

$(document).ready(function () {
    stylesTables();
    stylesActionLinksTables();
    stylesCreateLink();
});