using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mde.CurrencyConverter.Domain.Services
{
    public class RateService : IRateService
    {
        private Random random = new Random();
        private static List<CurrencyRate> inMemoryRates = new List<CurrencyRate> {
            new CurrencyRate("EUR", "BTC", 50840.27M),
            new CurrencyRate("EUR", "ETH", 3740.66M),
        };

    public async Task<CurrencyRate> GetCurrencyRate(string symbol)
        {
            return (await GetRates())
                .FirstOrDefault(cr => cr.Symbol.Equals(symbol));
        }

        public Task<IEnumerable<CurrencyRate>> GetRates()
        {
            return Task.FromResult(inMemoryRates.AsEnumerable());
        }

        public Task<IEnumerable<CurrencyRate>> DiscoverNewRates()
        {
            List<CurrencyRate> rates = new List<CurrencyRate>();
            int spawnRates = random.Next(1, 10);
            for(int rate = 0; rate < spawnRates; rate++) {
                var currencyRate = new CurrencyRate(
                    GetRandomCurrency(),
                    GetRandomCurrency(),
                    (decimal)(0.005 + random.NextDouble() * 10 * random.Next(0, 5)));
                rates.Add(currencyRate);
            }
            inMemoryRates.AddRange(rates);

            return Task.FromResult(rates.AsEnumerable());
        }

        private string GetRandomCurrency()
        {
            string currency = string.Empty;
            for(int i = 0; i <= 2; i++)
            {
                currency += GetRandomLetter();
            }
            return currency;
        }

        private char GetRandomLetter()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int num = random.Next(0, chars.Length);
            return chars[num];
        }
    }
}
