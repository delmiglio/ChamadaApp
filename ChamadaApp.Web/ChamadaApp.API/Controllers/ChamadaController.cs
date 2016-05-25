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
    [RoutePrefix("api/chamada")]
    public class ChamadaController : ApiController
    {
        [HttpGet]
        [ActionName("MateriaNovaChamada")]
        public HttpResponseMessage GetMateriaForChamada(int professorID)
        {
            Retorno obj = new Retorno();

            if (professorID == 0)
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Erro.";
                obj.RetornoDescricao = "Ocorreu um erro inesperado no sistema. Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetMateriaForChamada(Metodos.GetDiaDaSemana(), Metodos.GetCurrentTime(), professorID);

                if (obj.ObjRetorno == null)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Matéria não encontrada!";
                    obj.RetornoDescricao = "Não existem matérias passíveis de chamada para esta data.";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.ObjTypeName = obj.ObjRetorno.GetType().Name;
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

        [HttpGet]
        [ActionName("ChamadaAberta")]
        public HttpResponseMessage GetChamadaProfessor(int professorId, int sitChamadaId)
        {
            Retorno obj = new Retorno();

            if (professorId == 0)
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Houve falha na operação!";
                obj.RetornoDescricao = "Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetChamadaAbertaByProfessorId(professorId, sitChamadaId);

                if (obj.ObjRetorno == null)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Nenhuma chamada encontrada!";
                    obj.RetornoDescricao = "No momento, não existe chamada em aberto.";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.ObjTypeName = obj.ObjRetorno.GetType().Name;
                    obj.RetornoMensagem = "Foi encontrada uma chamada em andamento!";
                    //obj.RetornoDescricao = "";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPost]
        [ActionName("AbrirChamada")]
        public HttpResponseMessage PostAbrirChamada([FromBody] MateriaForChamadaVO materia)
        {
            Retorno obj = new Retorno();

            if (materia == null)
            {
                obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                obj.RetornoMensagem = "Houve falha na operação!";
                obj.RetornoDescricao = "A chamada não foi aberta. Tente novamente mais tarde!";
            }
            else
            {
                bool resposta = ChamadaDAO.AbrirChamada(materia, Metodos.GetCurrentTime());

                if (resposta)
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Operação realizada com sucesso!";
                    obj.RetornoDescricao = "A chamada já está disponível para resposta de presença dos alunos.";
                }
                else
                {
                    obj.TpRetorno = (int)TpRetornoEnum.Erro;
                    obj.RetornoMensagem = "Houve falha na operação!";
                    obj.RetornoDescricao = "A chamada não foi aberta. Tente novamente mais tarde!";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }       
                
        [HttpPut]
        [ActionName("EncerrarChamada")]
        public HttpResponseMessage PutEncerrarChamada([FromBody] ChamadaVO chamada)
        {
            Retorno obj = new Retorno();

            if (chamada != null)
            {
                obj.ListRetorno = ChamadaDAO.EncerrarChamada(chamada.Id, Metodos.GetCurrentTime()).Cast<object>().ToList();
                obj.ObjTypeName = typeof(AlunoChamadaVO).Name;
                obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                obj.RetornoMensagem = "Sucesso.";
                obj.RetornoDescricao = "A chamada foi encerrada.";
            }
            else
            {
                obj.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                obj.RetornoMensagem = "Tente Novamente.";
                obj.RetornoDescricao = "A chamada não foi encerrada.";
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        /*public HttpResponseMessage PutConcluirChamada([FromBody] ChamadaVO chamada)
        {
            Retorno obj = new Retorno();


            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }*/
    }
}
