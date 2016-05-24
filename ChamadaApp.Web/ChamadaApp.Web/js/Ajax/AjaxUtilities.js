// Métodos para que a Requisição Ajax Funcione Corretamente
function GetGenerico(url) {
    var dataEmJson = "";
    $.ajax({
        url: url,
        async: false,
        method: 'GET',
        success: function (data) {
            dataEmJson = JSON.parse(data);
        }
    });
    return dataEmJson;
}

function PostGenerico(url, objeto) {
    $.ajax({
        url: url,
        accepts: "application/json",
        async: true,
        cache: true,
        contentType: "application/json",
        crossDomain: true,
        dataType: 'JSON',
        data: JSON.stringify(objeto),
        error: function (response) {
            toastr.error("Um Erro Aconteceu \n Detalhes:" + response.data.error);
        },
        success: function (response) {
            toastr.success("Operação Realizada com Sucesso");
        },
        method: 'POST',
    });
}



function DeleteGenerico(url, id) {
    $.ajax({
        url: url + "?id=" + id,
        accepts: "application/json",
        async: true,
        cache: true,
        contentType: "application/json",
        crossDomain: true,
        dataType: 'JSON',
        error: function (response) {
            toastr.error("Um Erro Aconteceu \n Detalhes:" + response.data.error);
        },
        success: function (response) {
            toastr.success("Operação Realizada com Sucesso");
        },
        method: 'DELETE',
    });
}


function PutGenerico(url, objeto) {
    $.ajax({
        url: url,
        accepts: "application/json",
        async: true,
        cache: true,
        contentType: "application/json",
        crossDomain: true,
        dataType: 'JSON',
        data: JSON.stringify(objeto),
        error: function (response) {
            toastr.error("Um Erro Aconteceu \n Detalhes:" + response.data.error);
        },
        success: function (response) {
            toastr.success("Operação Realizada com Sucesso");
        },
        method: 'PUT',
    });
}


