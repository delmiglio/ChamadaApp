function MontaTabelaGenerica(objeto) {

    //Metodo 4
    var tabela = "<tr> <td> " + objeto.Nome + "</td> <td> " + objeto.Sobrenome + "</td> <td><button class=\"btn btn-primary\" onclick=\"GerarSenha(" + objeto.Id + ")\">Gerar Senha</button></td></tr>";
    $(tabela).appendTo("#corpoTabela");

   
}
