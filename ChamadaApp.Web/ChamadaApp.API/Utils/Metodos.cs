﻿using Newtonsoft.Json;
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
            CultureInfo culture = new CultureInfo("pt-BR");
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;

            string diaAtual = dtfi.GetDayName(DateTime.Now.DayOfWeek);

            return diaAtual.Substring(0, 3).ToUpper();
        }

        /// <summary>
        /// Retorna as horas e minutos atuais
        /// </summary>
        /// <returns>string contendo a hora atual</returns>
        public static string GetCurrentTime()
        {
            return DateTime.Now.ToShortTimeString();
        }

        public static T JsonToCustomObject<T>(object obj) where T : class
        {
            string json = JsonConvert.SerializeObject(obj);

            T novoObj = Activator.CreateInstance<T>();

            novoObj = JsonConvert.DeserializeObject<T>(json);

            return novoObj;
        }

        public static List<T> JsonToCustomObject<T>(List<object> listObj) where T : class
        {
            string json = JsonConvert.SerializeObject(listObj);

            List<T> novaLista = Activator.CreateInstance<List<T>>();

            novaLista = JsonConvert.DeserializeObject<List<T>>(json);

            return novaLista;
        }

        public static string GerarSenha()
        {
            string senha = "";
            Random random = new Random();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";          

            var result = new string(
                Enumerable.Repeat(chars, 4)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());         
            
            for (int n = 0; n < 2; n++)
                senha += random.Next(0, 10);

            return string.Concat(result.ToLower(), senha);
        }
    }
}