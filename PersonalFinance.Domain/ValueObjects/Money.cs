using System.Collections.Generic;

namespace PersonalFinance.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public Currency Currency { get; }
            
        public decimal Amount { get; }

        public Money(decimal amount, Currency currency)
        {
            Currency = currency;
            Amount = amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;

            yield return Currency;
        }

        public Money Add(Money money, decimal rate)
        {
            return new Money(Amount + money.Amount * rate, Currency);
        }
    }
}
