using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/usuario")]
    public class UsuarioController : ApiController
    {
        [HttpPost]
        [ActionName("GerarSenha")]
        public HttpResponseMessage GerarSenha(UsuarioVO usuario)
        {
            Retorno obj = new Retorno();

            if (usuario.Id > 0)
            {
                usuario.Senha = Metodos.GerarSenha();//Atribui nova senha de acesso
                usuario.Token = null;
                usuario.Ativo = false;

                obj.ObjRetorno = UsuarioDAO.ResetaSenhaAutenticacao(usuario);
                obj.TpRetorno = (int)TpRetornoEnum.Sucesso;
                obj.RetornoMensagem = "Senha Alterada!";
                obj.RetornoDescricao = "A senha do usuário " + (obj.ObjRetorno as UsuarioVO).ToString() + " foi alterada.";
            }
            else
            {
                obj.TpRetorno = (int)TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Erro";
                obj.RetornoDescricao = "Ocorreu um erro na requisição!";
            }           

            return new HttpResponseMessage
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        public HttpResponseMessage GetAlunos(string ra = null, string nomeSobrenome = null)
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

