using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ChamadaApp.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //CORS
            EnableCrossSiteRequests(config);

            // Web API routes
            AddRoutes(config);

            // Necessário Para Habilitar o Retorno de JSON neste formato: matheusSouzaLima: 
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
        }

        /// <summary>
        /// Habilita o CORS, permitindo a origem, rotas e metodos para acesso externo
        /// </summary>
        /// <param name="config">Config da Web Api</param>
        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
        }

        /// <summary>
        /// Configuração das rotas
        /// </summary>
        /// <param name="config">Config da Web Api</param>
        private static void AddRoutes(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",                
                defaults: new { id = RouteParameter.Optional, action = RouteParameter.Optional }
            );
        }
    }
}
