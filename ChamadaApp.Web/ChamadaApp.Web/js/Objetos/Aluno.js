var Aluno = function (id, login, nome, sobrenome, senha,
    token, tpUsuario, dtCriacao, dtAlteracao) {

    if (id)
        this.Id = id;

    if (login)
        this.Login = login;

    if (nome)
        this.Nome = nome;

    if (sobrenome)
        this.Sobrenome = sobrenome;

    if (senha)
        this.Senha = senha;

    if (token)
        this.Token = token;

    if (tpUsuario)
        this.tpUsuario = tpUsuario;

    if (dtAlteracao)
        this.DtAlteracao = dtAlteracao;

    if (dtCriacao)
        this.DtCriacao = dtCriacao;

    if (ativo)
        this.Ativo = ativo;

}


function GeraSenhaAluno() {

    var aluno = new Aluno();
    if (!aluno)
        PostGenerico("http://localhost:8090/api/usuario/", aluno);

}

function GetAlunos(ra, nome) {

    $("#corpoTabela").empty();
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
            MontaTabelaGenerica(alunos.ListRetorno[i]);
        }
    }
    else {
        toastr.info("não há resultados correspondentes a esses filtros","Informação");
    }
}