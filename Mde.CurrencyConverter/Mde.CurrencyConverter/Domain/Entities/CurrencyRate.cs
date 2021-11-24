using System;
using System.Collections.Generic;
using System.Text;

namespace Mde.CurrencyConverter.Domain
{
    public class CurrencyRate 
    {
        public CurrencyRate(string baseCurrency, string quoteCurrency, decimal rate)
        {
            BaseCurrency = baseCurrency;
            QuoteCurrency = quoteCurrency;  
            Rate = rate;
        }

        /// <summary>
        /// Rate FROM this currency
        /// </summary>
        public string BaseCurrency { get; set; }

        /// <summary>
        /// Rate TO this currency
        /// </summary>
        public string QuoteCurrency { get; set; }

        public decimal Rate { get; set; }

        public string Symbol => $"{BaseCurrency}-{QuoteCurrency}";
    }
}
