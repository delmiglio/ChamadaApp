$(document).ready(function () {

    $("a").click(function (event) {
        var link = $(this);

        if (link.attr("id").match("chamada")) {
            $("#tabela-alunos").hide("slow");
            $("#tabela-chamada").show("slow");
        }
        else if (link.attr("id").match("aluno")) {
            $("#tabela-chamada").hide("slow");
            $("#tabela-alunos").show("slow");
        }
        else {
            $("#tabela-alunos").hide("slow");
            $("#tabela-chamada").hide("slow");
        }

        event.preventDefault();
    });
});