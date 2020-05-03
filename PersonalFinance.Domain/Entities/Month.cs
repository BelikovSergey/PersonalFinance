using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Domain.Entities
{
    public class Month
    {
        public DateTime FirstDay { get; }

        private readonly List<Account> _accounts;

        private readonly ICurrencyRateProvider _currencyRateProvider;

        public IEnumerable<Account> Accounts => _accounts;

        public IEnumerable<Category> Categories { get; }

        public Money Total => _accounts.Select(x => x.Amount)
            .Aggregate(new Money(0, UserProfile.DefaultCurrency),
            (accumulate, money) => accumulate.Add(money,
                _currencyRateProvider.GetRate(money.Currency.Name, accumulate.Currency.Name)));

        public Money TotalIncome => _accounts.SelectMany(x => x.Transactions)
            .Where(x=>x.Type == TransactionType.Income)
            .Aggregate(new Money(0,UserProfile.DefaultCurrency),
            (money, transaction) => money.Add(transaction.Sum, transaction.Rate));

        public Money TotalSpent => _accounts.SelectMany(x => x.Transactions)
            .Where(x => x.Type == TransactionType.Spent)
            .Aggregate(new Money(0, UserProfile.DefaultCurrency),
                (money, transaction) => money.Add(transaction.Sum, transaction.Rate));

        public IDictionary<Category, Money> SpentByCategories => Categories.ToDictionary(x => x,
            GetSpentByCategory);

        protected Month()
        {
        }

        public Month(DateTime firstDay, IEnumerable<Category> categories, IEnumerable<Account> accounts, ICurrencyRateProvider currencyRateProvider)
        {
            FirstDay = firstDay;
            _currencyRateProvider = currencyRateProvider;
            _accounts = accounts.ToList();
            Categories = categories;
        }

        public Money GetSpentByCategory(Category category)
        {
            return _accounts.SelectMany(x => x.Transactions)
                .OfType<Spend>().Where(spend => spend.Category == category)
                .Aggregate(new Money(0, UserProfile.DefaultCurrency),
                    (money, transaction) => money.Add(transaction.Sum, transaction.Rate));
        }
    }
}
