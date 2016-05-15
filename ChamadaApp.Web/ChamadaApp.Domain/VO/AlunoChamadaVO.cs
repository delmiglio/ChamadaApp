using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    public class AlunoChamadaVO
    {
        public AlunoChamadaVO()
        {

        }

        public AlunoChamadaVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.ChamadaId = (int)registro["CHAMADAID"];
            this.AlunoId = (int)registro["ALUNOID"];
            this.SitAlunoChamadaId = (int)registro["SITALUNOCHAMADA"];
        }

        public int Id { get; set; }

        public int ChamadaId { get; set; }

        public int AlunoId { get; set; }

        public int SitAlunoChamadaId { get; set; }

        public DateTime DtPresenca { get; set; }
    }
}
