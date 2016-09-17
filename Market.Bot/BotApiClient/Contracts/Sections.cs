using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Market.Bot.BotApiClient.Contracts
{
    public enum Sections
    {
        [Description("по Москве")]
        Default = 0,
        [Description("по Московской области")]
        EasuzMoscowRegion = 1,
        Ekb = 2,
        [Description("по Волгограду")]
        Volgograd = 3,
        [Description("по Волгоградской области")]
        VolgogradRegion = 4,
        IrkutskRegion = 5,
        TyumenRegion = 6,
    }
}