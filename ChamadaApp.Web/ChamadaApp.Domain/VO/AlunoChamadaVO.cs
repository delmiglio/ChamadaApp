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
            AlunoVO aluno = new AlunoVO();
            aluno.Nome = registro["NOME"].ToString();
            aluno.Sobrenome = registro["SOBRENOME"].ToString();

            TpGenericoVO sitAlunoChamada = new TpGenericoVO();
            sitAlunoChamada.Descricao = registro["DESCRICAO"].ToString();

            this.Id = (int)registro["ID"];
            this.ChamadaId = (int)registro["CHAMADAID"];    
            this.DtPresenca = registro["DTPRESENCA"].ToString();
            this.Aluno = aluno;
            this.SitAlunoChamada = sitAlunoChamada;
        }

        public int Id { get; set; }

        public int ChamadaId { get; set; }

        public AlunoVO Aluno { get; set; }

        public TpGenericoVO SitAlunoChamada { get; set; }

        public string DtPresenca { get; set; }
    }
}
