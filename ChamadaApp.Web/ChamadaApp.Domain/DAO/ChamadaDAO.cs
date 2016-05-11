using ChamadaApp.Domain.ENUM;
using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChamadaApp.Domain.DAO
{
    public static class ChamadaDAO
    {
        /// <summary>
        /// Retorna a matéria atual para a abertura da chamada
        /// </summary>
        /// <param name="diaSemana">dia atual da semana</param>
        /// <param name="currTime">horas e minutos atuais</param>
        /// <param name="professorId">id do professor que leciona a matéria</param>
        /// <returns></returns>
        public static MateriaForChamadaVO GetMateriaForChamada(string diaSemana, string currTime, int professorId, int sitChamadaId)
        {
            try
            {
                string query = String.Format("SELECT HORARIOMATERIAPROFTURMA.ID AS 'HMPTID', TURMA.ID AS 'TURMAID', MATERIA.DESCRICAO AS 'MATERIA'," +

                                                " MODULO.DESCRICAO AS 'MODULO', CURSO.DESCRICAO AS 'CURSO'" +

                                                " FROM HORARIOMATERIAPROFTURMA" +

                                                " INNER JOIN MATERIAPROFTURMA ON MATERIAPROFTURMA.ID = HORARIOMATERIAPROFTURMA.MATERIAPROFTURMAID" +
                                                " INNER JOIN MATERIACURSO ON MATERIACURSO.ID = MATERIAPROFTURMA.MATERIACURSOID" +
                                                " INNER JOIN MATERIA ON MATERIA.ID = MATERIACURSO.MATERIAID" +
                                                " INNER JOIN TURMAMODULO ON TURMAMODULO.ID = MATERIAPROFTURMA.TURMAMODULOID" +
                                                " INNER JOIN MODULO ON MODULO.ID = TURMAMODULO.MODULOID" +
                                                " INNER JOIN TURMA ON TURMA.ID = TURMAMODULO.TURMAID" +
                                                " INNER JOIN CURSO ON CURSO.ID = TURMA.CURSOID" +

                                                " WHERE HORARIOMATERIAPROFTURMA.ATIVO = 1" +
                                                " AND HORARIOMATERIAPROFTURMA.DIASEMANA = \'{0}\'" +
                                                " AND(HORARIOMATERIAPROFTURMA.HORAINICIO <= \'{1}\'" +
                                                " AND HORARIOMATERIAPROFTURMA.HORATERMINO >= \'{1}\')" +

                                                " AND(MATERIAPROFTURMA.PROFESSORID = {2} AND MATERIAPROFTURMA.ATIVO = 1)" +

                                                " AND MODULO.ATIVO = 1 AND(HORARIOMATERIAPROFTURMA.ID NOT IN" +

                                                " (SELECT CHAMADA.HORARIOMATERIAPROFTURMAID FROM CHAMADA WHERE CHAMADA.SITCHAMADA = {3}" +

                                                " AND CHAMADA.DTCHAMADA <> GETDATE()))", diaSemana, currTime, professorId, sitChamadaId);

                DataTable data = MetodosDAO.ExecutaSelect(query);

                if (data.Rows.Count > 0)
                    return new MateriaForChamadaVO(data.Rows[0]);
                else
                    return null;
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
        }

        public static bool AbrirChamada(MateriaForChamadaVO materia, string time)
        {
            bool retorno;

            SqlConnection con = ConexaoDAO.GetConexao();            

            SqlTransaction transacao = con.BeginTransaction();

            try
            {
                List<AlunoVO> alunos = GetAlunosByTurmaId(materia.TurmaId);

                SqlCommand insertChamada = con.CreateCommand();

                insertChamada.CommandText = string.Format("INSERT INTO CHAMADA (DTCHAMADA, HORAINICIO, HORATERMINO, HORARIOMATERIAPROFTURMAID, SITCHAMADA)" +

                                           " OUTPUT INSERTED.ID" +

                                           " VALUES(GETDATE(), \'{0}\', \'{1}\', {2}, {3})", time, time, materia.HorarioMaterioProfTurmaId, (int)SitChamadaEnum.Aberta);

                insertChamada.Transaction = transacao;

                int chamadaId = (int)insertChamada.ExecuteScalar();


                if (chamadaId > 0)
                {
                    SqlCommand cmd;

                    foreach (AlunoVO aluno in alunos)
                    {                        
                        cmd = PreparaAlunoChamada(chamadaId, aluno.Id, con);
                        cmd.Transaction = transacao;
                        cmd.ExecuteNonQuery();
                    }
                }

                transacao.Commit();

                retorno = true;
            }
            catch (SqlException erro)
            {
                transacao.Rollback();
                retorno = false;                
            }
            finally
            {
                con.Close();
            }

            return retorno;
        }

        /// <summary>
        /// Prepara o aluno para ser criado seu registro na chamada
        /// </summary>
        /// <param name="chamadaId">identificação da chamada criada</param>
        /// <param name="alunoId">identificação do aluno</param>
        /// <param name="con">conexão aberta com o banco</param>
        /// <returns>comando de insert para o aluno</returns>
        private static SqlCommand PreparaAlunoChamada(int chamadaId, int alunoId, SqlConnection con)
        {
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = string.Format("INSERT INTO ALUNOCHAMADA (CHAMADAID, ALUNOID, SITALUNOCHAMADA, DTPRESENCA)" +

                            " VALUES({0}, {1}, {2}, null)", chamadaId, alunoId, (int)SitAlunoChamadaEnum.AguardandoChamada);
            return cmd;
        }

        /// <summary>
        /// Retorno os alunos ativos presentes na turma
        /// </summary>
        /// <param name="turmaId">identificação da turma</param>
        /// <returns>lista de alunos</returns>
        private static List<AlunoVO> GetAlunosByTurmaId(int turmaId)
        {
            List<AlunoVO> alunos = new List<AlunoVO>();

            string query = string.Format("SELECT ALUNO.* FROM ALUNO" +

                                         " INNER JOIN ALUNOTURMA ON ALUNOTURMA.ALUNOID = ALUNO.ID" +

                                         " INNER JOIN USUARIO ON USUARIO.ID = ALUNO.ID" +

                                         " WHERE ALUNOTURMA.TURMAID = {0}" +

                                         " AND ALUNOTURMA.ATIVO = 1 AND USUARIO.ATIVO = 1" +

                                         " AND ALUNO.SITALUNOID = 1 ", turmaId);

            DataTable data = MetodosDAO.ExecutaSelect(query);

            foreach (DataRow registro in data.Rows)
            {
                alunos.Add(new AlunoVO(registro));
            }

            return alunos;
        }
    }
}
