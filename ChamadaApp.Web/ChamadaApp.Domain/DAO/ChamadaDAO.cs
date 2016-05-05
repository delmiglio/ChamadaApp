using ChamadaApp.Domain.VO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public static MateriaForChamadaVO GetMateriaForChamada(string diaSemana, string currTime, int professorId)
        {
            

            string query = String.Format("SELECT HORARIOMATERIAPROFTURMA.ID AS 'HMPTID', MATERIA.DESCRICAO AS 'MATERIA', MODULO.DESCRICAO AS 'MODULO', CURSO.DESCRICAO AS 'CURSO'" +

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

                                            " (SELECT CHAMADA.HORATIOMATERIAPROFTURMAID FROM CHAMADA WHERE CHAMADA.DTCHAMADA <> GETDATE()))", diaSemana, currTime, professorId);

            DataTable data = MetodosDAO.ExecutaSelect(query);

            if (data.Rows.Count > 0)
                return new MateriaForChamadaVO(data.Rows[0]);
            else
                return null;
        }
    }
}
