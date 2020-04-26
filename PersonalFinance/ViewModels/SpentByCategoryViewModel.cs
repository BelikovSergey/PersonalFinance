using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.ViewModels
{
    class SpentByCategoryViewModel
    {
        private readonly Category _category;

        public Category Model => _category;

        private readonly Month _month;

        public string Name => _category.Name;

        public Money Spent => _month.GetSpentByCategory(_category);

        public SpentByCategoryViewModel(Category category, Month month)
        {
            _category = category;
            _month = month;
        }
    }
}
