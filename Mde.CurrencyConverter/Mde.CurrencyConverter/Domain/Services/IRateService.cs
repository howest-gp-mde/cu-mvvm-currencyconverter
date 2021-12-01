using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mde.CurrencyConverter.Domain.Services
{
    public interface IRateService
    {
        Task<IEnumerable<CurrencyRate>> GetRates();

        Task<CurrencyRate> GetCurrencyRate(string symbol);

        Task<IEnumerable<CurrencyRate>> DiscoverNewRates();
    }
}