using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    class AlunoVO : UsuarioVO
    {
        public AlunoVO()
        {

        }

        public int Id { get; set; }
        public int SitAlunoId { get; set; }

    }
}
