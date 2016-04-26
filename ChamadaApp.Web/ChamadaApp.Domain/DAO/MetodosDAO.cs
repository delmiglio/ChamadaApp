using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.DAO
{
    public class MetodosDAO
    {
        public static DataTable ExecutaSelect(string sql)
        {
            SqlConnection conexao = ConexaoDAO.GetConexao();
            try
            {
                // Instancia um Objeto Tabela e retorna ele preenchido
                DataTable tabela = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conexao);
                adapter.Fill(tabela);
                return tabela;
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
