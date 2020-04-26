using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Caliburn.Micro;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.ViewModels
{ 
    class AccountViewModel : PropertyChangedBase
    {
        public Account Model { get; }

        public string Name => Model.Name;

        public Money Amount => Model.Amount;

        public AccountViewModel(Account model)
        {
            Model = model;
        }

        public void Spend(DateTime date, Money money, Category category)
        {
            Model.Spend(date, money, category);
            NotifyOfPropertyChange(() => Amount);
        }

        public void Add()
        {
            MessageBox.Show("zzz");
        }
    }
}
