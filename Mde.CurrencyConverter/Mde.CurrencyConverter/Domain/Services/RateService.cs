using System.Collections.Generic;

namespace Mde.CurrencyConverter.Domain.Services
{
    public class RateService : IRateService
    {
        public IEnumerable<CurrencyRate> GetRates()
        {
            return new List<CurrencyRate> {
                new CurrencyRate("EUR", "BTC", 50840.27M),
                new CurrencyRate("EUR", "ETH", 3740.66M),
            };
        }
    }
}
