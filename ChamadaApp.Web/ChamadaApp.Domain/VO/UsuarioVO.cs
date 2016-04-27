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
            this.Login = re["LOGIN"].ToString();
            this.Senha = re["SENHA"].ToString(); 
            this.Token = re["TOKEN"].ToString();
            this.TpUsuario = (int)re["TPUSUARIOID"];
            this.DtCriacao = (DateTime)re["DTCRIACAO"];
            this.DtAlteracao = (DateTime)re["DTALTERACAO"];
            this.Ativo = (bool)re["ATIVO"];
        }

        
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Login { get; set; }
        
        public string Senha { get; set; }

        public string Token { get; set; }
        
        public int TpUsuario { get; set; }
     
        public DateTime DtCriacao { get; set; }
        
        public DateTime DtAlteracao { get; set; }
        
        public bool Ativo { get; set; }

    }
}
