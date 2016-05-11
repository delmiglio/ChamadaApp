using ChamadaApp.Domain.VO;
using System;
using System.Data;

namespace ChamadaApp.Domain.DAO
{
    public class LoginDAO
    {
        /// <summary>
        /// Retorna um objeto da instancia Retorno preenchido
        /// </summary>
        /// <param name="login">login do usuario</param>
        /// <param name="senha">senha do usuario</param>
        /// <returns>retorna o usuario correspondente caso encontrado</returns>
        public static UsuarioVO GetUserByLogin(string login, string senha)
        {
            UsuarioVO user = new UsuarioVO();

            try
            {
                string getLogin = String.Format("SELECT * FROM USUARIO WHERE USUARIO.LOGIN = {0} AND " +
                                                "USUARIO.SENHA = {1} AND USUARIO.ATIVO = 1", login, senha);

                DataTable data = MetodosDAO.ExecutaSelect(getLogin);

                if (data.Rows.Count > 0)
                    user = new UsuarioVO(data.Rows[0]);
                else
                    user = null;              

                return user;
            }
            catch(Exception erro)
            {
                throw new Exception(erro.Message);
            }   
        }   
    }
}
