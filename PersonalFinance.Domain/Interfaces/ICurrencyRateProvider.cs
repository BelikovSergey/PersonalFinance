using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.Interfaces
{
    public interface ICurrencyRateProvider
    {
        decimal GetRate(string sourceCurrencyName, string targetCurrencyName);
    }
}
