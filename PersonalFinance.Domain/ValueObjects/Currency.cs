using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Domain.ValueObjects
{
    public class Currency : ValueObject
    {
        public static readonly Currency RUB = new Currency("₽", "RUB");
        public static readonly Currency USD = new Currency("$", "USD");
        public static readonly Currency EUR = new Currency("€", "EUR");

        public string Symbol { get; }

        public string Name { get; }

        public Currency(string symbol, string name)
        {
            Symbol = symbol;
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }

        public override string ToString()
        {
            return Symbol;
        }
    }
}
