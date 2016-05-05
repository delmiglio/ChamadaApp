using ChamadaApp.Api.Utils;
using ChamadaApp.Domain.DAO;
using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ChamadaApp.Api.Controllers
{
    [RoutePrefix("api/materiaDoDia")]
    public class MateriaDoDiaController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get(int professorID)
        {
            MateriaForChamadaVO materia = ChamadaDAO.GetMateriaForChamada(Metodos.GetDiaDaSemana(), Metodos.GetCurrentTime(), professorID);

            return new HttpResponseMessage()
            {
                Content = new StringContent(Metodos.ObjectToJson(materia)),
                StatusCode = HttpStatusCode.OK

            };
        }
    }
}
