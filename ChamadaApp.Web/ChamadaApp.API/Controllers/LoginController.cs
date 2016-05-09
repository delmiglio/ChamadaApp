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
        public HttpResponseMessage Get(string login, string senha)
        {
            Retorno obj;

            //Verifica se os parametros foram informados.
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
            {
                obj = new Retorno();

                obj.IsErro = true;
                obj.ErroMensagem = "Login Inválido!";
                obj.ErroDescricao = "Para efetuar o login, deverá ser informado os campos Login e Senha.";
            }
            else         
                obj = LoginDAO.GetUserByLogin(login, senha);

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(obj)),
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
