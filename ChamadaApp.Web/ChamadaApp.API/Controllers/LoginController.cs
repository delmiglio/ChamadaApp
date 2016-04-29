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
            UsuarioVO user = LoginDAO.GetUsuarioRA(login, senha);            

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(user)),
                StatusCode = HttpStatusCode.OK

            };
        }
    }
}
