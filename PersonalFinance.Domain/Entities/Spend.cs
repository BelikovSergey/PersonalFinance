using System;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain.Entities
{
    public class Spend : Transaction
    {
        public Category Category { get; }

        public Spend(Guid id, DateTime date, Money sum, decimal rate, Category category) : 
            base(id, date, sum, rate, TransactionType.Spent)
        {
            Category = category;
        }

        public override Money Apply(Money sourceMoney)
        {
            return sourceMoney.Subtract(Sum, Rate);
        }
    }
}
