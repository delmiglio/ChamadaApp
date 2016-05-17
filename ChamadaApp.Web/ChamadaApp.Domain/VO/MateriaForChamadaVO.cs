using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    public class MateriaForChamadaVO
    {
        public MateriaForChamadaVO()
        {

        }

        public MateriaForChamadaVO(DataRow registro)
        {
            this.HorarioMaterioProfTurmaId = (int)registro["HMPTID"];
            this.TurmaId = (int)registro["TURMAID"];
            this.MateriaDescricao = registro["MATERIA"].ToString();
            this.ModuloDescricao = registro["MODULO"].ToString();
            this.CursoDescricao = registro["CURSO"].ToString();
        }

        public int HorarioMaterioProfTurmaId { get; set; }

        public int TurmaId { get; set; }

        public string MateriaDescricao { get; set; }

        public string ModuloDescricao { get; set; }

        public string CursoDescricao { get; set; }

    }
}
