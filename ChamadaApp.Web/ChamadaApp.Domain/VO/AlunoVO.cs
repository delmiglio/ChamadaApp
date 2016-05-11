using System.Data;

namespace ChamadaApp.Domain.VO
{
    class AlunoVO : UsuarioVO
    {
        public AlunoVO()
        {

        }

        public AlunoVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.SitAlunoId = (int)registro["SITALUNOID"];
        }              

        public int SitAlunoId { get; set; }

    }
}
