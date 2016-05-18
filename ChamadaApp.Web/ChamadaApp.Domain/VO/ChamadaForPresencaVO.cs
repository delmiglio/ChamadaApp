using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    public class ChamadaForPresencaVO
    {
        public ChamadaForPresencaVO()
        {

        }

        public ChamadaForPresencaVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.AlunoId = (int)registro["ALUNOID"];
            this.Situacao = registro["SITUACAO"].ToString();
            this.Materia = registro["MATERIA"].ToString();
            this.Professor = registro["NOME"].ToString() + " " + registro["SOBRENOME"].ToString();
        }

        public int Id { get; set; }

        public int AlunoId { get; set; }

        public string Situacao { get; set; }

        public string Materia { get; set; }

        public string Professor { get; set; }
    }
}
