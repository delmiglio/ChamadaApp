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
            this.DtChamada = DataFormatada(registro["DTCHAMADA"].ToString());
            this.HoraInicio = registro["HORAINICIO"].ToString();
            this.HoraTermino = registro["HORATERMINO"].ToString();            
            this.SitChamada = registro["DESCRICAO"].ToString();
            this.Materia = registro["MATERIA"].ToString();
            this.Modulo = registro["MODULO"].ToString();
            this.Curso = registro["CURSO"].ToString();
        }

        public int Id { get; set; }        

        public string DtChamada { get; set; }

        public string HoraInicio { get; set; }

        public string HoraTermino { get; set; }

        public string SitChamada { get; set; }

        public string Materia { get; set; }

        public string Modulo { get; set; }

        public string Curso { get; set; }

        private string DataFormatada(string fullDate)
        {
            DateTime data = Convert.ToDateTime(fullDate);
            return data.ToShortDateString();
        }
    }
}
