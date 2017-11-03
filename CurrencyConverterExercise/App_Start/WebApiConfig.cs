using System.Net.Http.Headers;
using System.Web.Http;

namespace CurrencyConverterExercise
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name: "CalculationApi",
                routeTemplate: "api/calc/{cFrom}/{cTo}/{amount}",
                defaults: new { amount = RouteParameter.Optional, controller = "Calculation" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { action = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes
                  .Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
