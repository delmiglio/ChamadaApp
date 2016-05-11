using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/chamada")]
    public class ChamadaController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage Post([FromBody] MateriaForChamadaVO materia)
        {
            Retorno obj = new Retorno();

            if (materia == null)
            {
                obj.TpRetorno = TpRetornoEnum.SemRetorno;
                obj.RetornoMensagem = "Houve falha na operaçãoo!";
                obj.RetornoDescricao = "A chamada não foi aberta. Tente novamente mais tarde!";
            }
            else
            {
                bool resposta = ChamadaDAO.AbrirChamada(materia, Metodos.GetCurrentTime());

                if (resposta)
                {
                    obj.TpRetorno = TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Operação realizada com sucesso!";
                    obj.RetornoDescricao = "A chamada já está disponível para resposta de presença dos alunos.";
                }
                else
                {
                    obj.TpRetorno = TpRetornoEnum.Erro;
                    obj.RetornoMensagem = "Houve falha na operaçãoo!";
                    obj.RetornoDescricao = "A chamada não foi aberta. Tente novamente mais tarde!";
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
