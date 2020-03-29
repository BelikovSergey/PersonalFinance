using System;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain.Entities
{
    public class Transfer : Transaction
    {
        private Account TargetAccount { get; }

        public Transfer(Guid id, DateTime date, Money sum, decimal rate, Account targetAccount) : 
            base(id, date, sum, rate, TransactionType.Transfer)
        {
            TargetAccount = targetAccount;
        }
    }
}
