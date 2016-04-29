using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamadaApp.Api.Utils
{
    /// <summary>
    /// Contém métodos para uso geral da api
    /// </summary>
    public class Metodos
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
    }
}