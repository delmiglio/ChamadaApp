﻿using ChamadaApp.Api.Utils;
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
        public HttpResponseMessage GetMateriaForChamada(int professorID)
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

                if (obj.ObjRetorno == null)
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

        [HttpPost]
        public HttpResponseMessage PostAbrirChamada([FromBody] MateriaForChamadaVO materia)
        {
            Retorno obj = new Retorno();

            if (materia == null)
            {
                obj.TpRetorno = TpRetornoEnum.SemRetorno;
                obj.RetornoMensagem = "Houve falha na operação!";
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

        [HttpGet]
        public HttpResponseMessage GetChamadaProfessor(int professorId)
        {
            Retorno obj = new Retorno();

            if (professorId == 0)
            {
                obj.TpRetorno = TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Houve falha na operação!";
                obj.RetornoDescricao = "Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetChamadaAbertaByProfessorId(professorId, (int)SitChamadaEnum.Aberta);

                if (obj.ObjRetorno == null)
                {
                    obj.TpRetorno = TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Nenhuma chamada encontrada!";
                    obj.RetornoDescricao = "No momento, não existe chamada em aberto.";
                }
                else
                {
                    obj.TpRetorno = TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Foi encontrada uma chamada em andamento!";
                    obj.RetornoDescricao = ".";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
        
        [HttpGet]        
        public HttpResponseMessage GetChamadaAluno(int alunoID)
        {
            Retorno obj = new Retorno();

            if(alunoID == 0)
            {
                obj.TpRetorno = TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Houve falha na operação!";
                obj.RetornoDescricao = "Tente novamente mais tarde!";
            }
            else
            {
                obj.ObjRetorno = ChamadaDAO.GetChamadaAbertaByAlunoId(alunoID, (int)SitAlunoChamadaEnum.AguardandoChamada);

                if(obj.ObjRetorno == null)
                {
                    obj.TpRetorno = TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Nenhuma chamada encontrada!";
                    obj.RetornoDescricao = "No momento, não existe chamada em aberto a ser respondida.";
                }
                else
                {
                    obj.TpRetorno = TpRetornoEnum.Sucesso;
                    obj.RetornoMensagem = "Foi encontrada uma chamada a ser respondida!";
                    obj.RetornoDescricao = ".";
                }
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPut]
        public HttpResponseMessage PutResponderChamada(int alunoChamadaId)
        {
            Retorno obj = new Retorno();

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPut]
        public HttpResponseMessage PutConcluirChamada(int chamadaId)
        {
            Retorno obj = new Retorno();

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
                
        private HttpResponseMessage GetAlunosChamadaNaoPresentes(int chamadaId)
        {
            Retorno obj = new Retorno();

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}