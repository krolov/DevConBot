using Market.Bot.BotApiClient.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.Bot.BotApiClient
{
    public interface IBotApiClient
    {
        Task<StatisticResult> GetOrdersAsync(FilterModel filter);

        Task<StatisticResult> GetPurchasesAsync(FilterModel filter);
    }
}
