using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Market.Bot.BotApiClient.Contracts;
using Flurl.Http;
using Newtonsoft.Json.Linq;
using Microsoft.Bot.Builder.Internals.Fibers;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

namespace Market.Bot.BotApiClient
{
    public class BotApiClient : IBotApiClient
    {
        private static dynamic Convert(dynamic source, Type dest)
        {
            return System.Convert.ChangeType(source, dest);
        }

        const string BotApiUserName = "otc-market-bot";
        const string BotApiPassword = "otc-market-bot";
        const string BotApiHost = "http://api.market.stable.otc.ru/";
        //const string BotApiHost = "http://webaggregator.lh/";

        private async Task<string> getToken()
        {
            var responseString = await (BotApiHost + "token")
                .PostUrlEncodedAsync(new
                {
                    username = BotApiUserName,
                    password = BotApiPassword,
                    grant_type = "password"
                }).ReceiveString();
            JToken token = JObject.Parse(responseString);
            return token.SelectToken("access_token").ToString();
        }

        public async Task<StatisticResult> GetOrdersAsync(FilterModel filter)
        {
            var key = getToken();
            var result = await
                (BotApiHost + "Order/Get").SetQueryParams(filter)
                .WithHeaders(new { authorization = "bearer " + key }).GetJsonAsync();
            StatisticResult item = Convert(result, typeof(StatisticResult));
            return item;
        }

        public async Task<StatisticResult> GetPurchasesAsync(FilterModel filter)
        {
            var key = getToken();
            var result = await
                (BotApiHost + "Purchase/Get")
                .SetQueryParams(filter)
                .WithHeaders(new { authorization = "bearer " + key }).GetJsonAsync();
            return new StatisticResult() { TotalItems = result.TotalItems, TotalSum = result.TotalSum };

        }
    }
}