using System.Collections.Generic;
using System.Collections.ObjectModel;
using PersonalFinance.ViewModels;

namespace PersonalFinance {
    class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        public decimal Balance => 100500;

        public List<AccountViewModel> Accounts { get; }
        public List<AccountViewModel> Categories { get; }

        public ObservableCollection<HistoryItemViewModel> History { get; }

        public ShellViewModel()
        {
            Accounts = new List<AccountViewModel>
            {
                new AccountViewModel
                {
                    Name = "Наличные",
                    Total = 123456,
                    Currency = "р."
                },
                new AccountViewModel
                {
                    Name = "Карта",
                    Total = 23578,
                    Currency = "р."
                }
            };

            Categories = new List<AccountViewModel>
            {
                new AccountViewModel
                {
                    Name = "Продукты",
                    Total = 1230,
                    Currency = "р."
                },
                new AccountViewModel
                {
                    Name = "Кафе",
                    Total = 1350,
                    Currency = "р."
                },
                new AccountViewModel
                {
                    Name = "Развлечения",
                    Total = 5678,
                    Currency = "р."
                }
            };

            History = new ObservableCollection<HistoryItemViewModel>()
            {
                new HistoryItemViewModel()
                    { },
                new HistoryItemViewModel()
                {
                }
            };
        }
    }
}