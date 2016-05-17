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
            this.Aluno = new AlunoVO(registro);
            this.SitAlunoChamada = new TpGenericoVO(registro);
            this.DtPresenca = registro["DTPRESENCA"].ToString();
        }

        public int Id { get; set; }

        public int ChamadaId { get; set; }

        public AlunoVO Aluno { get; set; }

        public TpGenericoVO SitAlunoChamada { get; set; }

        public string DtPresenca { get; set; }
    }
}
