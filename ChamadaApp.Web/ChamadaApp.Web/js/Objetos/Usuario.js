function GerarSenha(userId) {      

    var obj = "";

    if (userId != null) {
        var usuario = new Usuario();
        usuario.Id = userId;

        obj = PostGenerico("http://localhost/api/usuario/GerarSenha", usuario);
    }

    if (obj != null) {
        toastr.success(obj.RetornoDescricao, obj.RetornoMensagem);
        $("#corpoTabelaAluno").empty();
        MontaTabelaUsuarios(obj.ObjRetorno);
    }
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
        for (var i = 0; i < alunos.ListRetorno.length; i++){
            MontaTabelaUsuarios(alunos.ListRetorno[i]);
        }
    }
    else {
        toastr.info("não há resultados correspondentes a esses filtros","Informação");
    }
}