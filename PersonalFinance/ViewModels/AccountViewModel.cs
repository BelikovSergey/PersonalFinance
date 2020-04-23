using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.ValueObjects;

namespace PersonalFinance.ViewModels
{ 
    class AccountViewModel
    {
        private readonly Account _account;

        public string Name => _account.Name;

        public Money Amount => _account.Amount;

        public AccountViewModel(Account account)
        {
            _account = account;
        }

        public void Add()
        {
            MessageBox.Show("zzz");
        }
    }
}
