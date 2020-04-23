using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Converters
{
    class MoneyToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var money = value as Money;
            if (money == null) return "";
            return $"{money.Amount:N2} {money.Currency.Symbol}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
