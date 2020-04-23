using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.Application
{
    class ApplicationService : IApplicationService
    {
        private readonly ICurrencyRateProvider _currencyRateProvider;

        private List<Category> _categories = new List<Category>()
        {
            new Category {Name="Продукты"},
            new Category {Name="Кафе"},
            new Category {Name="Развлечения"},
            new Category {Name="Здоровье"},
            new Category {Name="Хозяйство"},
            new Category {Name="Развитие"},
            new Category {Name="Транспорт"},
            new Category {Name="Прочее"}
        };

        private readonly List<Account> _accounts = new List<Account>();

        public IEnumerable<Category> Categories => _categories;

        public ApplicationService(ICurrencyRateProvider currencyRateProvider)
        {
            _currencyRateProvider = currencyRateProvider;
            _accounts.AddRange(new List<Account>
            {
                new Account(Guid.NewGuid(), "Наличные", new Money(10523, Currency.RUB), new List<Transaction>(), _currencyRateProvider),
                new Account(Guid.NewGuid(), "Карта", new Money(100572, Currency.RUB), new List<Transaction>(), _currencyRateProvider),
                new Account(Guid.NewGuid(), "Кредитка", new Money(-25789, Currency.RUB), new List<Transaction>(), _currencyRateProvider),
                new Account(Guid.NewGuid(), "Баксы", new Money(12572, Currency.USD), new List<Transaction>(), _currencyRateProvider),
            });
        }

        public Month GetMonth(DateTime firstDay)
        {
            var month = new Month(firstDay, Categories, _accounts, _currencyRateProvider);
            return month;
        }
    }
}
