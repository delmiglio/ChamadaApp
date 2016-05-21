using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/aluno")]
    public class AlunoController : ApiController
    {
        [HttpPost]
        [Route("gerarSenha")]
        public async Task<HttpResponseMessage> GerarSenha(AlunoVO aluno)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent(Metodos.ObjectToJson(new Retorno()
                {
                    RetornoMensagem = "Funcionou!!!",
                    RetornoDescricao = "AEEEEE",
                    ObjRetorno = aluno,
                    ObjTypeName = GetType().Name,
                    TpRetorno = (int)TpRetornoEnum.Sucesso

                }
                )),
                StatusCode = System.Net.HttpStatusCode.OK
            };
        }
    }
}

