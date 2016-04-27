using ChamadaApp.Domain.VO;
using System;
using System.Data;

namespace ChamadaApp.Domain.DAO
{
    public class LoginDAO
    {
        public static UsuarioVO GetUsuarioRA(string ra)
        {
            string getLogin = String.Format("SELECT * FROM USUARIO WHERE USUARIO.LOGIN = {0}", ra);

            DataTable data = MetodosDAO.ExecutaSelect(getLogin);

            if (data.Rows.Count > 0)
                return new UsuarioVO(data.Rows[0]);
            else
                return null;  
        }   
    }
}
