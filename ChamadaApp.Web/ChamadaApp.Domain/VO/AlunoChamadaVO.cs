using System;
using System.Collections.Generic;
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

        public int Id { get; set; }

        public int ChamadaId { get; set; }

        public int SitAlunoChamadaId { get; set; }

        public DateTime DtPresenca { get; set; }
    }
}
