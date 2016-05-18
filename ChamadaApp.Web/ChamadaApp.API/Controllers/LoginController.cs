using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]        
        public HttpResponseMessage GetUsuarioByLogin(string login, string senha)
        {
            Retorno obj = new Retorno();

            //Verifica se os parametros foram informados.
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(senha))
            {             
                obj.TpRetorno = TpRetornoEnum.Erro;
                obj.RetornoMensagem = "Login Inválido!";
                obj.RetornoDescricao = "Para efetuar o login, deverá ser informado os campos Login e Senha.";
            }
            else
            {

                UsuarioVO user = LoginDAO.GetUserByLogin(login, senha);

                if(user == null)
                {                    
                    obj.TpRetorno = TpRetornoEnum.SemRetorno;
                    obj.RetornoMensagem = "Login Inválido!";
                    obj.RetornoDescricao = "Verifique se as credenciais estão corretas!";
                }
                else
                {
                    obj.TpRetorno = TpRetornoEnum.Sucesso;
                    obj.ObjRetorno = user;
                    obj.ObjTypeName = user.GetType().Name;
                }                
            }

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        public HttpResponseMessage GetValidaAcesso()
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
