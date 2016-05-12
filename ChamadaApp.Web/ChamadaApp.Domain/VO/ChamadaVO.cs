using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    public class ChamadaVO
    {
        public ChamadaVO()
        {

        }

        public ChamadaVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.DtChamada = (DateTime)registro["DTCHAMADA"];
            this.HoraInicio = registro["HORAINICIO"].ToString();
            this.HoraTermino = registro["HORATERMINO"].ToString();
            this.HorarioMateriaProfTurmaId = (int)registro["HORARIOMATERIAPROFTURMAID"];
            this.SitChamadaId = (int)registro["SITCHAMADA"];
        }

        public int Id { get; set; }

        public int HorarioMateriaProfTurmaId { get; set; }

        public DateTime DtChamada { get; set; }

        public string HoraInicio { get; set; }

        public string HoraTermino { get; set; }

        public int SitChamadaId { get; set; }
    }
}
