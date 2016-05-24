using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [Route("gerarSenha")]
        public async Task<HttpResponseMessage> GerarSenha(AlunoVO aluno)
        {
            string token = Metodos.GerarToken();

            var retorno = new Retorno()
            {
                RetornoMensagem = "Funcionou!!!",
                RetornoDescricao = token,
                ObjRetorno = aluno,
                ObjTypeName = GetType().Name,
                TpRetorno = (int)TpRetornoEnum.Sucesso

            };

            return new HttpResponseMessage
            {
                Content = new StringContent(Metodos.ObjectToJson(retorno)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        public HttpResponseMessage Get(string ra = null, string nomeSobrenome = null)
        {
            Retorno retorno = new Retorno();

            retorno.ListRetorno = UsuarioDAO.GetAlunoWithFilter(ra, nomeSobrenome).Cast<object>().ToList();

            if (retorno.ListRetorno == null)
            {
                retorno.TpRetorno = (int)TpRetornoEnum.SemRetorno;
                retorno.RetornoMensagem = "Não há resultados correspondentes a esse filtro";
                retorno.RetornoDescricao = "Verifique os filtros";
            }
            else
            {
                retorno.TpRetorno = (int)TpRetornoEnum.Sucesso;
                retorno.RetornoMensagem = "Há Resultados";
                retorno.RetornoDescricao = retorno.ListRetorno.Count.ToString() + "(s) resultados encontrados";
                retorno.ObjTypeName = typeof(UsuarioVO).Name;
            }
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(Metodos.ObjectToJson(retorno));
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}

