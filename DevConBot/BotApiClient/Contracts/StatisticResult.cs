using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevConBot.BotApiClient.Contracts
{
    public class StatisticResult
    {
        public decimal TotalItems { get; set; }

        public decimal TotalSum { get; set; }
    }
}