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
        public static Retorno GetUserByLogin(string login, string senha)
        {
            Retorno obj = new Retorno();

            try
            {
                string getLogin = String.Format("SELECT * FROM USUARIO WHERE USUARIO.LOGIN = {0} AND " +
                                                "USUARIO.SENHA = {1} AND USUARIO.ATIVO = 1", login, senha);

                DataTable data = MetodosDAO.ExecutaSelect(getLogin);

                if (data.Rows.Count > 0)   
                    obj.ObjRetorno = new UsuarioVO(data.Rows[0]);
                else
                {
                    //Se não encontrar o usuário retorna o seguinte erro.
                    obj.IsErro = true;
                    obj.ErroMensagem = "Login Inválido!";
                    obj.ErroDescricao = "Verifique se as credenciais estão corretas!";
                }

                return obj;
            }
            catch(Exception erro)
            {
                //caso aconteça alguma exceção é retornado seus detelhes...
                obj.IsErro = true;
                obj.ErroMensagem = "Ocorreu um erro na operação.";
                obj.ErroMensagem = erro.Message;

                return obj;
            }   
        }   
    }
}
