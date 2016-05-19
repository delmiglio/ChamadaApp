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
            this.DtPresenca = registro["DTPRESENCA"].ToString();
            this.alunoNome = registro["NOME"].ToString() + " " + registro["SOBRENOME"].ToString();
            this.sitAlunoChamada = registro["DESCRICAO"].ToString();
        }

        public int Id { get; set; }

        public int ChamadaId { get; set; }

        public string alunoNome { get; set; }

        public string sitAlunoChamada { get; set; }

        public string DtPresenca { get; set; }
    }
}
