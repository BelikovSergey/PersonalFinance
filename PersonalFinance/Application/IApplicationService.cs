using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Application
{
    interface IApplicationService
    {
        Currency DefaultCurrency { get; }

        IEnumerable<Currency> Currencies { get; }

        Month GetMonth(DateTime firstDay);
    }
}
