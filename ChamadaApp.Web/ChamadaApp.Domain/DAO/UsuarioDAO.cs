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

                               " FROM USUARIO INNER JOIN TPUSUARIO ON TPUSUARIO.ID = USUARIO.TPUSUARIOID " +

                               " WHERE USUARIO.ATIVO = 1 ";

                string where = " AND ";

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
    }
}
