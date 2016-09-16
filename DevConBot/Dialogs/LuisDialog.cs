using DevConBot.BingTranslator;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;


namespace DevConBot.Dialogs
{
    [Serializable]
    [LuisModel("84bc6ef0-800b-4dc0-816a-36162c91fac1", "706f723d09f947bab1efd62c4ee2c0f0")]
    public class LuisDialog : LuisDialog<object>
    {
        [LuisIntent("")]
        public async Task ProcessNone(IDialogContext context, LuisResult result)
        {
            var message = "Я не понимаю";

            await context.PostAsync(message, "ru-RU");

            context.Wait(MessageReceived);
        }

        [LuisIntent("hello")]
        public async Task ProcessHello(IDialogContext context, LuisResult result)
        {
            var c = Thread.CurrentThread.CurrentCulture;

            var messages = new string[]
            {
                "Привет",
                "Здравствуй!",
                "Привет! Чем могу быть полезен?"
            };

            var message = messages[(new Random()).Next(messages.Count() - 1)];
            await context.PostAsync(message, "ru-RU");
            //await context.PostWithTranslationAsync(message, "en-US", Thread.CurrentThread.CurrentCulture.Name);

            context.Wait(MessageReceived);
        }

        protected override async Task<string> GetLuisQueryTextAsync(IDialogContext context, IMessageActivity message)
        {
            //return Task.FromResult(message.Text); // in source code

            if (message.Locale == null)
            {
                message.Locale = "ru-RU";
            }

            var baseLuisText = await base.GetLuisQueryTextAsync(context, message);

            if ( message.Locale != "en-US")
            {
                try
                {
                    var bingTranslatorClient = new BingTranslatorClient("Test187871", "dAnT3r/eIc8KedBRUgRCV+juxpf4Wl312jn1Bd2SXzk=");
                    return await bingTranslatorClient.Translate(baseLuisText, message.Locale, "en-US");
                }
                catch (Exception)
                {
                    return null;
                }
            }
            return baseLuisText;
        }
    }
}