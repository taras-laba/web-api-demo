using System.Web.Http;
using System.Web.Http.Tracing;
using WebApi.Common.Extensions;

namespace WebApi.Common
{
    public static class WebApiConfig
    {
        public static void Configure(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "Process",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { controller = "process", id = RouteParameter.Optional }
                );

            config.Formatters.Add(new ImageFormatter());

            config.MessageHandlers.Add(new MethodOverrideHandler());
            config.MessageHandlers.Add(new ExecutionTimeHandler());

            //config.Formatters.JsonFormatter.Indent = true;
            //config.Formatters.XmlFormatter.Indent = true;

            config.Services.Replace(typeof(ITraceWriter), new DebugTraceWriter());
        }
    }
}
