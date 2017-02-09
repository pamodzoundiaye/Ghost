using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Syn.Bot.Siml;
using System.IO;
using System.Web.Script.Serialization;

namespace API.Controllers
{
    public class BotController : ApiController
    {

        [Route("api/bot/{name}")]
        public IHttpActionResult Get(string name)
        {
            /*
            var simlBot = new SimlBot();
            var botUser = new BotUser(simlBot, "pamodzou");
            var packageString = File.ReadAllText(@"C:\Users\Pamodzou Ndiaye\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\anglais.simlpk");
            simlBot.PackageManager.LoadFromString(packageString);
             */
            
            var chatRequest = new ChatRequest(name, WebApiConfig.botUser);
            var chatResult = WebApiConfig.simlBot.Chat(chatRequest);
            var answer = chatResult.BotMessage;
            return Ok(answer);
        }
    }
}
