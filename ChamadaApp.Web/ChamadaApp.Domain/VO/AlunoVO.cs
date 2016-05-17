using System.Data;

namespace ChamadaApp.Domain.VO
{
    public class AlunoVO : UsuarioVO
    {
        public AlunoVO()
        {

        }

        public AlunoVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.Nome = registro["NOME"].ToString();
            this.Sobrenome = registro["SOBRENOME"].ToString();
            this.SitAlunoId = (int)registro["SITALUNOID"];
        }              

        public int SitAlunoId { get; set; }

    }
}
