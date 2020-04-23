using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Infrastructure
{
    class CurrencyRateProvider : ICurrencyRateProvider
    {
        public decimal GetRate(string sourceCurrencyName, string targetCurrencyName)
        {
            if (sourceCurrencyName == targetCurrencyName) return 1;

            if (sourceCurrencyName == "USD" && targetCurrencyName == "RUB") return 76.54m;
            if (sourceCurrencyName == "RUB" && targetCurrencyName == "USD") return 1.0m/76.54m;

            return 1;
        }
    }
}
