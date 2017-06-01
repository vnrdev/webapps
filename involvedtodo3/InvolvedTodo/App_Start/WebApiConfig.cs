using System;
using System.Diagnostics;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace InvolvedTodo
{
    public class WebApiConfig : System.Web.HttpApplication
    {
        public static void Register(HttpConfiguration config)
        {;
            // Zorg ervoor dat routes kunnen werken via dynamische attributen (nieuw in WebApi) die in de querystring worden meegegeven, te herkennen aan {controller} en {id}
            config.MapHttpAttributeRoutes();

            var enableCorsAttribute = new EnableCorsAttribute("http://trevalius.duckdns.org:8082",
                                                   "Origin, Content-Type, Accept",
                                                   "GET, PUT, POST, DELETE, OPTIONS");
            config.EnableCors(enableCorsAttribute);
            
            

            // We geven JSON terug, ook al wordt er text/html gevraagd. We maken JSON ons default repsonseformaat.
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new RequestHeaderMapping("Accept", "text/html", StringComparison.InvariantCultureIgnoreCase, true,
                    "application/json"));            
        }
    }
}