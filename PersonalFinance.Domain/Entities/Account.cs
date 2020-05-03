using System;
using System.Collections.Generic;
using System.Linq;
using PersonalFinance.Domain.Events;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain.Entities
{
    public class Account : Entity
    {
        public string Name { get; set; }

        public Money Amount
        {
            get
            {
                var res = _startAmount;

                foreach (var transaction in _transactions)
                {
                    res = transaction.Apply(res);
                }

                return res;
            }
        }

        public Currency Currency => _startAmount.Currency;

        private readonly List<Transaction> _transactions;

        public IEnumerable<Transaction> Transactions => _transactions.OrderByDescending(x => x.Date);

        private readonly Money _startAmount;

        private readonly ICurrencyRateProvider _currencyRateProvider;

        protected Account()
        {
        }

        public Account(Guid id, string name, Money startAmount, IEnumerable<Transaction> transactions,
            ICurrencyRateProvider currencyRateProvider)
        {
            Id = id;
            Name = name;
            _startAmount = startAmount;
            _currencyRateProvider = currencyRateProvider;
            _transactions = transactions.ToList();
        }

        private void AddTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            DomainEvents.Raise(new NewTransaction
            {
                Transaction = transaction
            });
        }

        public void Income(DateTime date, Money money)
        {
            AddTransaction(new Transaction(
                Guid.NewGuid(),
                date,
                money,
                _currencyRateProvider.GetRate(
                    money.Currency.Name, 
                    _startAmount.Currency.Name),
                TransactionType.Income
            ));
        }

        public void Spend(DateTime date, Money money, Category category)
        {
            AddTransaction(new Spend(
                Guid.NewGuid(),
                date,
                money,
                _currencyRateProvider.GetRate(
                    money.Currency.Name,
                    _startAmount.Currency.Name),
                category
            ));
        }

        public void Transfer(DateTime date, Money money, Account targetAccount)
        {
            AddTransaction(new Transfer(
                Guid.NewGuid(),
                date,
                money,
                _currencyRateProvider.GetRate(
                    money.Currency.Name,
                    _startAmount.Currency.Name),
                targetAccount
            ));
        }

        public void Correction(DateTime date, Money money)
        {
            AddTransaction(new Transaction(
                Guid.NewGuid(),
                date,
                money,
                _currencyRateProvider.GetRate(
                    money.Currency.Name,
                    _startAmount.Currency.Name),
                TransactionType.Correction
            ));
        }
    }
}
