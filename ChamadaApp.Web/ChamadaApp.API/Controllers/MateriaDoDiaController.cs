using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.ENUM;
using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/materiaDoDia")]
    public class MateriaDoDiaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int professorID)
        {
            Retorno obj = new Retorno();

            if (professorID == 0)
            {
                obj.TpRetorno = TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Erro.";
                obj.RetornoDescricao = "Ocorreu um erro inesperado no sistema. Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetMateriaForChamada(Metodos.GetDiaDaSemana(), Metodos.GetCurrentTime(), professorID, (int)SitChamadaEnum.Aberta);

                if(obj.ObjRetorno == null)
                {
                    obj.TpRetorno = TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Matéria não encontrada!";
                    obj.RetornoDescricao = "Não existem matérias passíveis de chamada para esta data.";
                }
                else
                {
                    obj.TpRetorno = TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "A seguinte matéria foi encontrada.";
                    obj.RetornoDescricao = "Efetue a abertura da chamada para a disponibilização aos alunos.";
                }
            }
            
            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK

            };
        }
    }
}
