﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Market.Bot.BotApiClient.Contracts
{
    public class FilterModel
    {
        public List<Sections> Sections { get; set; }

        public DateRange Range { get; set; }
    }
}