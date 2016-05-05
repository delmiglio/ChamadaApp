using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ChamadaApp.Api.Utils
{
    /// <summary>
    /// Contém métodos para uso geral da api
    /// </summary>
    public static class Metodos
    {
        /// <summary>
        /// Recebe um objeto de qualquer classe e converte para formato Json
        /// </summary>
        /// <param name="obj">Instancia do objeto a ser convertido para Json</param>
        /// <returns>retorna uma string Json com os dados do objeto</returns>
        public static string ObjectToJson(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// Esse método retorna a 3 primeiras letras do dia atual da semana 
        /// </summary>
        /// <returns>string contendo o dia da semana</returns>
        public static string GetDiaDaSemana()
        {
            DateTime diaAtual = new DateTime();

            return diaAtual.ToString("ddd", new CultureInfo("pt-br")).ToUpper();
        }

        /// <summary>
        /// Retorna as horas e minutos atuais
        /// </summary>
        /// <returns>string contendo a hora atual</returns>
        public static string GetCurrentTime()
        {
            return DateTime.Now.ToShortTimeString();
        }
    }
}