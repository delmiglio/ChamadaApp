﻿function MontaTabelaAlunos(objeto) {

    var tabela = "<tr> <td> " + objeto.Login + "</td> <td> " + objeto.Nome + "</td> <td> " + objeto.Sobrenome + "</td> <td> " + objeto.TpUsuarioDesc + "</td> <td> " + objeto.Senha + "</td> <td> " + objeto.Ativo + "</td> <td><button class=\"btn btn-primary\" onclick=\"GerarToken()\">Gerar Senha</button></td></tr>";
    $(tabela).appendTo("#corpoTabelaAluno");

   
}


function MontaTabelaChamada(objeto) {

    var tabela = "<tr> <td> " + objeto.Nome + "</td> <td> " + objeto.Sobrenome + "</td> <td><button class=\"btn btn-primary\" onclick=\"GerarToken()\">Gerar Senha</button></td></tr>";
    $(tabela).appendTo("#corpoTabelaChamada");


}
