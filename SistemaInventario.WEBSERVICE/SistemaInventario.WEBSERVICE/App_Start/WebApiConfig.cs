using SistemaInventario.WEBSERVICE.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SistemaInventario.WEBSERVICE
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            //MODIFICADOOOOOOOOOOO SE AGREGA LA REFERENCIA A LA VALIDACIÓN DEL TOKEN
            config.MessageHandlers.Add(new TokenValidation());

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
