using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain.Entities
{
    public class Transaction : Entity
    {
        public DateTime Date { get; }

        public Money Sum { get; set; }

        public decimal Rate { get; }

        public TransactionType Type { get; }

        public Transaction(Guid id, DateTime date, Money sum, decimal rate, TransactionType type)
        {
            Id = id;
            Date = date;
            Sum = sum;
            Rate = rate;
            Type = type;
        }

        public virtual Money Apply(Money sourceMoney)
        {
            return sourceMoney.Add(Sum, Rate);
        }
    }
}
