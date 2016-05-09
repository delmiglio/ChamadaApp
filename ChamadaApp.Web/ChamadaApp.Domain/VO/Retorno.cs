using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChamadaApp.Domain.VO
{
    /// <summary>
    /// Essa classe possui as propriedades a serem retornadas em uma requisição...
    /// </summary>
    public class Retorno
    {     
        public bool IsErro { get; set; }

        public string ErroMensagem { get; set; }

        public string ErroDescricao { get; set; }

        public object ObjRetorno { get; set; }
    }
}