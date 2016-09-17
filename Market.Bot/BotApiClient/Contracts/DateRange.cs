using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Market.Bot.BotApiClient.Contracts
{
    public enum DateRange
    {
        [Description("за вчера")]
        yesterday = 0,

        [Description("за сегодня")]
        today = 1,

        [Description("за неделю")]
        week = 2,

        [Description("за месяц")]
        month = 3,

        [Description("за год")]
        year = 4
    }
}