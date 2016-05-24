using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ChamadaApp.Domain.DAO
{
    public static class MetodosDAO
    {
        /// <summary>
        /// Execulta uma comando select no banco de dados
        /// </summary>
        /// <param name="sql">comando de seleção</param>
        /// <returns>o resultado do comando</returns>
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
            catch(SqlException sqlErro)
            {
                //tratar o erro aqui...
                return null;
            }
            catch (Exception erro)
            {
                //tratar o erro aqui...
                return null;
            }
            finally
            {
                conexao.Close();
            }
        }

        /// <summary>
        /// Executa um determinado comando no banco de dados
        /// </summary>
        /// <param name="sql">Inserir, Altera e Excluir</param>
        public static void ExecutaSQL(string sql)
        {
            SqlConnection conexao = ConexaoDAO.GetConexao();
            try
            {
                SqlCommand comando = new SqlCommand(sql, conexao);
                comando.ExecuteNonQuery();
            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
