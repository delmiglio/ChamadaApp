using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Data;


namespace ChamadaApp.Domain.DAO
{
    public static class UsuarioDAO
    {
        public static List<UsuarioVO> GetAlunoWithFilter(string ra, string nomeSobrenome)
        {
            List<UsuarioVO> usuarios = new List<UsuarioVO>();

            try
            {
                string query = "SELECT USUARIO.*, TPUSUARIO.DESCRICAO " +

                               " FROM USUARIO INNER JOIN TPUSUARIO ON TPUSUARIO.ID = USUARIO.TPUSUARIOID ";                               

                string where = " WHERE ";

                if (!string.IsNullOrWhiteSpace(ra))
                    where += String.Format("USUARIO.[LOGIN] LIKE '%{0}%'",ra);
                else if (!string.IsNullOrWhiteSpace(nomeSobrenome))
                    where += String.Format("(USUARIO.NOME + ' ' + USUARIO.SOBRENOME) LIKE '%{0}%'",nomeSobrenome);

                query = query + where;

                DataTable data = MetodosDAO.ExecutaSelect(query);

                foreach (DataRow registro in data.Rows)
                {
                    usuarios.Add(new UsuarioVO(registro));
                }

                return usuarios;
            }
            catch (Exception erro)
            {
                return usuarios;
            }
        }

        public static UsuarioVO ResetaSenhaAutenticacao(UsuarioVO usuario)
        {
            string update = string.Format("UPDATE USUARIO SET USUARIO.SENHA = \'{0}\', USUARIO.TOKEN = NULL, USUARIO.DTALTERACAO = \'{1}\', USUARIO.ATIVO = 0 " + 

                                          " WHERE USUARIO.ID = {2}", usuario.Senha, DateTime.Now.ToShortDateString(), usuario.Id);

            MetodosDAO.ExecutaSQL(update);

            string query = string.Format("SELECT USUARIO.*, TPUSUARIO.DESCRICAO " +

                           " FROM USUARIO INNER JOIN TPUSUARIO ON TPUSUARIO.ID = USUARIO.TPUSUARIOID " +
                           
                           " WHERE USUARIO.ID = {0}", usuario.Id);

            DataTable data = MetodosDAO.ExecutaSelect(query);

            if (data.Rows.Count == 1)
                return new UsuarioVO(data.Rows[0]);
            else
                return null;
        }
    }
}
