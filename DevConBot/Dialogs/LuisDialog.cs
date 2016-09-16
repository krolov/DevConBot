using DevConBot.BingTranslator;
using DevConBot.BotApiClient;
using DevConBot.BotApiClient.Contracts;
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

            var message = messages[(new Random()).Next(messages.Count())];
            await context.PostAsync(message, "ru-RU");
            //await context.PostWithTranslationAsync(message, "en-US", Thread.CurrentThread.CurrentCulture.Name);

            context.Wait(MessageReceived);
        }

        [LuisIntent("bye")]
        public async Task ProcessBye(IDialogContext context, LuisResult result)
        {
            var c = Thread.CurrentThread.CurrentCulture;

            var messages = new string[]
            {
                "Пока!",
                "До новых встреч!"
            };

            var message = messages[(new Random()).Next(messages.Count())];
            await context.PostAsync(message, "ru-RU");
            //await context.PostWithTranslationAsync(message, "en-US", Thread.CurrentThread.CurrentCulture.Name);

            context.Wait(MessageReceived);
        }

        [LuisIntent("thank")]
        public async Task ProcessThank(IDialogContext context, LuisResult result)
        {
            var c = Thread.CurrentThread.CurrentCulture;

            var messages = new string[]
            {
                "Всегда рад помочь!",
                "Шутка про пожалуйста."
            };

            var message = messages[(new Random()).Next(messages.Count())];
            await context.PostAsync(message, "ru-RU");
            //await context.PostWithTranslationAsync(message, "en-US", Thread.CurrentThread.CurrentCulture.Name);

            context.Wait(MessageReceived);
        }

        [LuisIntent("help")]
        public async Task ProcessHelp(IDialogContext context, LuisResult result)
        {
            var c = Thread.CurrentThread.CurrentCulture;

            var message = "Пока я умею только здороваться и показывать вот этот блок помощи";
            await context.PostAsync(message, "ru-RU");

            context.Wait(MessageReceived);
        }

        [LuisIntent("getPurchases")]
        public async Task ProcessPurchases(IDialogContext context, LuisResult result)
        {
            var filter = new FilterModel();
            var DateRange = "month";
            var Section = "all";

            EntityRecommendation entityContainer;
            if (result.TryFindEntity("section", out entityContainer))
            {
                Section = entityContainer.Entity;
                filter.Sections = IntentEntryHelper.GetSection(entityContainer.Entity);
            }

            if (result.TryFindEntity("dateRange", out entityContainer))
            {
                DateRange = entityContainer.Entity;
                filter.Range = IntentEntryHelper.GetDateRange(entityContainer.Entity);
            }

            var message = $"Информация по закупкам. Секция: {Section}. Период: {DateRange}.";
            await context.PostAsync(message, "ru-RU");

            context.Wait(MessageReceived);
        }

        [LuisIntent("getAgreements")]
        public async Task ProcessAgreements(IDialogContext context, LuisResult result)
        {
            var filter = new FilterModel();
            var DateRange = "month";
            var Section = "common";

            EntityRecommendation entityContainer;
            if (result.TryFindEntity("section", out entityContainer))
            {
                Section = entityContainer.Entity;
                filter.Sections = IntentEntryHelper.GetSection(entityContainer.Entity);
            }

            if (result.TryFindEntity("dateRange", out entityContainer))
            {
                DateRange = entityContainer.Entity;
                filter.Range = IntentEntryHelper.GetDateRange(entityContainer.Entity);
            }

            var message = $"Информация по договорам. Секция: {Section}. Период: {DateRange}.";
            await context.PostAsync(message, "ru-RU");

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

            if (message.Locale != "en-US")
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