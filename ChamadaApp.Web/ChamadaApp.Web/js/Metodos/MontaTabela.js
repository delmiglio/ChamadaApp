function MontaTabelaGenerica(objeto) {

    var tabela = "<tr> <td> " + objeto.Nome + "</td> <td> " + objeto.Sobrenome + "</td> <td><button class=\"btn btn-primary\" onclick=\"GerarToken()\">Gerar Senha</button></td></tr>";
    $(tabela).appendTo("#corpoTabelaAluno");

   
}
