using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Bot.BotApiClient.Contracts
{
    public enum DateRange
    {
        yesterday = 0,
        today = 1,
        week = 2,
        month = 3,
        year = 4
    }
}