using API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Syn.Bot.Siml;
using System.IO;
using System.Net.Http.Headers;

namespace API
{
    public static class WebApiConfig
    {
        public static SimlBot simlBot = new SimlBot();
        public static BotUser botUser = new BotUser(simlBot, "pamodzou");
        public static string packageString = File.ReadAllText(@"C:\Users\Pamodzou Ndiaye\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\anglais.simlpk");

        public static void Register(HttpConfiguration config)
        {
            config.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));
            // Web API configuration and services
            simlBot.PackageManager.LoadFromString(packageString);
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
