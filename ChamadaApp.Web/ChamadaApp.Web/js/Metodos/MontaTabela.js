function MontaTabelaUsuarios(objeto) {

    var row = "<tr>" +
        "<td> " + objeto.Login + "</td>" +
        "<td> " + objeto.Nome + "</td>" +
        "<td> " + objeto.Sobrenome + "</td>" +
        "<td> " + objeto.TpUsuarioDesc + "</td>" +
        "<td> " + objeto.Senha + "</td>" +
        "<td> " + objeto.Ativo + "</td>" +
        "<td> " +
            "<a class=\"btnGerarSenha btn btn-primary\" href=\"javascript:GerarSenha('"+objeto.Id+"')\">Gerar Senha</a>" +
        "</td>" +
        "</tr>";

    $("#corpoTabelaAluno").append(row);   
}

function MontaTabelaChamada(objeto) {

    var tabela = "<tr> <td> " + objeto.Nome + "</td> <td> " + objeto.Sobrenome + "</td> <td><button class=\"btn btn-primary\" onclick=\"GerarToken()\">Gerar Senha</button></td></tr>";
    $(tabela).appendTo("#corpoTabelaChamada");
}
