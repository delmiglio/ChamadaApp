using System;
using System.Data;

namespace ChamadaApp.Domain.VO
{
    public class UsuarioVO
    {
        public UsuarioVO()
        {

        }

        public UsuarioVO(DataRow re)
        {
            this.Id = (int)(re["ID"]);
            this.Login = re["LOGIN"].ToString();
            this.Nome = re["NOME"].ToString();
            this.Sobrenome = re["SOBRENOME"].ToString();
            this.Senha = re["SENHA"].ToString();
            this.Token = re["TOKEN"].ToString();
            this.TpUsuario = (int)re["TPUSUARIOID"];
            this.DtCriacao = re["DTCRIACAO"].ToString();
            this.DtAlteracao = re["DTALTERACAO"].ToString();
            this.Ativo = (bool)re["ATIVO"];
            this.TpUsuarioDesc = re.Table.Columns.Contains("DESCRICAO") ? re["DESCRICAO"].ToString() : null;            
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public string Token { get; set; }

        public int TpUsuario { get; set; }

        public string DtCriacao { get; set; }

        public string DtAlteracao { get; set; }

        public bool Ativo { get; set; }

        public string TpUsuarioDesc { get; set; }

        public override string ToString()
        {
            return string.Concat(Nome, " ", Sobrenome);
        }
    }
}
