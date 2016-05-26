function GerarToken() {

    //var aluno = new Aluno();
    var resultado;
    
    
        resultado = PostGenerico("http://localhost:8090/api/usuario/", new Aluno())

    if(resultado.length > 0)
        toastr.info(resultado.retorno.RetornoMensagem);
}

function GetAlunos(ra, nome) {

    $("#corpoTabelaAluno").empty();
    var ra = $("#RA").val();
    var nome = $("#Nome").val();
    var url = "http://localhost:8090/api/usuario";
    if (ra && nome)
        url += "?ra=" + ra + "&nomeSobrenome=" + nome;
    else if (ra)
        url += "?ra=" + ra;
    else if (nome)
        url += "?nomeSobrenome=" + nome;

    var alunos = GetGenerico(url);

    if (alunos.ListRetorno.length > 0) {
        for (var i = 0; i < alunos.ListRetorno.length; i++) {
            MontaTabelaAlunos(alunos.ListRetorno[i]);
        }
    }
    else {
        toastr.info("não há resultados correspondentes a esses filtros","Informação");
    }
}