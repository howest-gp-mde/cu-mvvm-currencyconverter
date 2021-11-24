using System.Collections.Generic;

namespace Mde.CurrencyConverter.Domain.Services
{
    public interface IRateService
    {
        IEnumerable<CurrencyRate> GetRates();
    }
}