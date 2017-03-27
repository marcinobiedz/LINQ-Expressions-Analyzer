using LINQapi.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LINQapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            Constants.db = new MyDbSet();
            // Web API configuration and services
            var cors = new EnableCorsAttribute(Constants.UI_URL, "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
