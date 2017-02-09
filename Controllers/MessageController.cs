using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Syn.Bot.Siml;
using System.IO;

namespace API.Controllers
{
    public class MessageController : ApiController
    {
        Message[] messages = new Message[] {
            new Message {Id="1",Content="Bonjour"},
            new Message {Id="2",Content="Bien et toi"},
            new Message {Id="3",Content="Au revoir"}
        };
        public IEnumerable<Message> GetAllMessages(){
            return messages;
        }
        public IHttpActionResult GetMessage(string input){
            var simlBot = new SimlBot();
            var botUser = new BotUser(simlBot, "pamodzou");
            var packageString = File.ReadAllText(@"C:\Users\Pamodzou Ndiaye\Documents\Visual Studio 2015\Projects\ConsoleApplication1\ConsoleApplication1\anglais.simlpk");
            simlBot.PackageManager.LoadFromString(packageString);
            var chatRequest = new ChatRequest(input, botUser);
            var chatResult = simlBot.Chat(chatRequest);
            var answer = chatResult.BotMessage;
            Console.WriteLine("reponse: "+answer);
                //messages.FirstOrDefault((p) => p.Id == id);
            if (answer == null)
            {
                return NotFound();
            }
            return Ok(answer);
        }

    }
}
