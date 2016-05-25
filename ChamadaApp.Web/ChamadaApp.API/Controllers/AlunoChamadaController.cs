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
    [RoutePrefix("api/alunoChamada")]
    public class AlunoChamadaController : ApiController
    {
        [HttpGet]
        [ActionName("GetChamadaAberta")]
        public HttpResponseMessage GetChamadaAluno(int alunoID)
        {
            Retorno obj = new Retorno();

            if (alunoID == 0)
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Houve falha na operação!";
                obj.RetornoDescricao = "Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetChamadaAbertaByAlunoId(alunoID, (int)SitAlunoChamadaEnum.AguardandoChamada);

                if (obj.ObjRetorno == null)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Nenhuma chamada encontrada!";
                    obj.RetornoDescricao = "No momento, não existe chamada em aberto a ser respondida.";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.ObjTypeName = obj.ObjRetorno.GetType().Name;
                    obj.RetornoMensagem = "Foi encontrada uma chamada a ser respondida!";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPut]
        [ActionName("ResponderChamada")]
        public HttpResponseMessage PutResponderChamada([FromBody] ChamadaForPresencaVO alunoChamada)
        {
            Retorno obj = new Retorno();

            if (alunoChamada.Id > 0)
            {
                bool resposta = ChamadaDAO.MarcarPresenca(alunoChamada.Id, Metodos.GetCurrentTime());

                if (resposta)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Sucesso";
                    obj.RetornoDescricao = "Presença Confirmada!";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Erro;
                    obj.RetornoMensagem = "Aconteceu um erro na requisição.";
                    obj.RetornoDescricao = "Houve um erro na requisição, tente novamente. Caso o erro perista contate o professor!";
                }
            }
            else
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Erro.";
                obj.RetornoDescricao = "Houve um erro na requisição, tente novamente!";
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}