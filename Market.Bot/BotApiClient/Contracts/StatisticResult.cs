using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Bot.BotApiClient.Contracts
{
    [JsonArray]
    public class StatisticResult
    {
        public decimal TotalItems { get; set; }

        public decimal TotalSum { get; set; }
    }
}