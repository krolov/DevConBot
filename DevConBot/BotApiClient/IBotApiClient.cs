using DevConBot.BotApiClient.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevConBot.BotApiClient
{
    public interface IBotApiClient
    {
        Task<StatisticResult> GetOrdersAsync(FilterModel filter);

        Task<StatisticResult> GetPurchasesAsync(FilterModel filter);
    }
}
