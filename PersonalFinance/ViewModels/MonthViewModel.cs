using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.ViewModels
{
    class MonthViewModel
    {
        public Month Model { get; }

        public DateTime FirstDay => Model.FirstDay;

        public Money Total => Model.Total;
        public Money Income => Model.TotalIncome;
        public Money Spent => Model.TotalSpent;

        public IEnumerable<Category> Categories => Model.Categories;

        public IEnumerable<AccountViewModel> Accounts => Model.Accounts.Select(x => new AccountViewModel(x));

        public MonthViewModel(Month month)
        {
            Model = month;
        }

        public override string ToString()
        {
            return Model.FirstDay.ToString("MMMM yyyy");
        }
    }
}
