using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    public class HomeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Teste"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpGet]
        [Route("{id}")]
        public HttpResponseMessage Get(int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Teste" + id),
                StatusCode = HttpStatusCode.OK
            };
        }


        [HttpPost]
        public HttpResponseMessage Post([FromBody] JToken obj)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("obj"),
                StatusCode = HttpStatusCode.OK
            };
        }

        [HttpPut]
        [Route("{id}")]
        public HttpResponseMessage Put([FromBody] JToken obj, [FromUri] int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("obj"),
                StatusCode = HttpStatusCode.OK
            };
        }


        [HttpDelete]
        [Route("{id}")]
        public HttpResponseMessage Delete([FromUri] int id)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("obj"),
                StatusCode = HttpStatusCode.OK
            };
        }




    }
}
