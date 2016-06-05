function GerarSenha(userId, Login) {      

    if (userId != null) {
        var usuario = new Usuario();
        usuario.Id = userId;
        PostGenerico("http://localhost/api/usuario/GerarSenha", usuario);
    }

    toastr.success("A senha do usuário: '"+ Login +"' foi alterada.", "Informção");

    GetUsuarios(Login, null);
}

function Usuario() {
    Usuario.Id;
}

function GetUsuarios(ra, nome) {

    $("#corpoTabelaAluno").empty();
    var ra = $("#RA").val();
    var nome = $("#Nome").val();
    var url = "http://localhost/api/usuario";
    if (ra && nome)
        url += "?ra=" + ra + "&nomeSobrenome=" + nome;
    else if (ra)
        url += "?ra=" + ra;
    else if (nome)
        url += "?nomeSobrenome=" + nome;

    var alunos = GetGenerico(url);

    if (alunos.ListRetorno.length > 0) {        
        MontaTabelaAlunos(alunos.ListRetorno);
    }
    else {
        toastr.info("não há resultados correspondentes a esses filtros","Informação");
    }
}