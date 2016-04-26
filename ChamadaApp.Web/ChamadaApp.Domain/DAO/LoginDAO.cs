using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.DAO
{
    public class LoginDAO
    {
        public static UsuarioVO GetUsuarioRA(string ra)
        {
            string getLogin = String.Format("SELECT * FROM USUARIO WHERE USUARIO.LOGIN = {0}", ra);

            DataTable result = MetodosDAO.ExecutaSelect(getLogin);

            if (result.Rows.Count > 0)
                return MontaUsuario(result.Rows[0]);
            else
                return null;
        }

        private static UsuarioVO MontaUsuario(DataRow registro)
        {
            UsuarioVO user = new UsuarioVO();

            user.Id = Convert.ToInt32(registro["ID"]);
            user.Login = registro["LOGIN"].ToString();
            user.Nome = registro["NOME"].ToString();
            user.Sobrenome = registro["SOBRENOME"].ToString();
            
            return user;
        }
    }
}
