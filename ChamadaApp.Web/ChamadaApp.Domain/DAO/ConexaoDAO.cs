using System.Data.SqlClient;

namespace ChamadaApp.Domain.DAO
{
    class ConexaoDAO
    {
        /// <summary>
        /// Retorna a conexao com o banco de dados BDTCC
        /// </summary>
        /// <returns></returns>
        public static SqlConnection GetConexao()
        {
            string con = "Data Source=localhost;Initial Catalog=BDTCC;User ID=sa;Password=123456";
            SqlConnection conexao = new SqlConnection(con);
            conexao.Open();

            return conexao;
        }
    }
}
