using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance
{
    static class ExtensionMethods
    {
        public static DateTime FirstDay(this DateTime dateTime)
        {
            return dateTime.AddDays(1 - dateTime.Day).Date;
        }
    }
}
