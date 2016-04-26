using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]        
        public HttpResponseMessage Get(string ra)
        {
            UsuarioVO user = LoginDAO.GetUsuarioRA(ra);            

            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(user)),
                StatusCode = HttpStatusCode.OK

            };
        }
    }
}
