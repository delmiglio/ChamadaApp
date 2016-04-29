using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.VO
{
    /// <summary>
    /// Essa classe é uma representação das tabelas CURSO, MATERIA, SITALUNO, 
    /// SITALUNOCHAMADA, SITCHAMADA, SITTURMA e TPUSUARIO presentes no banco de dados...
    /// </summary>
    public class TpGenericoVO
    {
        public TpGenericoVO()
        {

        }

        public TpGenericoVO(DataRow registro)
        {
            this.Id = (int)registro["ID"];
            this.Descricao = registro["DESCRICAO"].ToString();
            this.Ordem = (int)registro["ORDEM"];
            this.Ativo = (bool)registro["ATIVO"];
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
    }
}
