var Aluno = function(id, login, nome, sobrenome, senha, token, tpUsuario, dtCriacao, dtAlteracao) {
   
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
        PostGenerico("http://localhost:8080/api/aluno/", aluno);
    
}