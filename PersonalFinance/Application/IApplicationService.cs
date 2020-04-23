using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.Application
{
    interface IApplicationService
    {
        Month GetMonth(DateTime firstDay);
    }
}
