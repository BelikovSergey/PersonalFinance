using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using PersonalFinance.Application;
using PersonalFinance.Domain.Entities;
using PersonalFinance.ViewModels;

namespace PersonalFinance {
    class ShellViewModel : Caliburn.Micro.PropertyChangedBase, IShell
    {
        private readonly IApplicationService _applicationService;

        private MonthViewModel _month;

        public MonthViewModel Month
        {
            get => _month;
            set
            {
                _month = value;
                NotifyOfPropertyChange();
                NotifyOfPropertyChange(nameof(Accounts));
                NotifyOfPropertyChange(nameof(Categories));
            }
        }

        public IEnumerable<SpentByCategoryViewModel> Categories =>
            _month.Categories.Select(x => new SpentByCategoryViewModel(x, _month.Model));
        public IEnumerable<AccountViewModel> Accounts => Month.Accounts;

        public ObservableCollection<HistoryItemViewModel> History { get; }

        public EnterMoneyViewModel EnterMoney { get; }

        public ShellViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;

            var today = DateTime.Today;

            var month = _applicationService.GetMonth(today.AddDays(1 - today.Day));
            Month = new MonthViewModel(month);

            EnterMoney = new EnterMoneyViewModel();

            //Accounts = new List<AccountViewModel>
            //{
            //    new AccountViewModel
            //    {
            //        Name = "Наличные",
            //        Total = 123456,
            //        Currency = "р."
            //    },
            //    new AccountViewModel
            //    {
            //        Name = "Карта",
            //        Total = 23578,
            //        Currency = "р."
            //    }
            //};

            //Categories = new List<AccountViewModel>
            //{
            //    new AccountViewModel
            //    {
            //        Name = "Продукты",
            //        Total = 1230,
            //        Currency = "р."
            //    },
            //    new AccountViewModel
            //    {
            //        Name = "Кафе",
            //        Total = 1350,
            //        Currency = "р."
            //    },
            //    new AccountViewModel
            //    {
            //        Name = "Развлечения",
            //        Total = 5678,
            //        Currency = "р."
            //    }
            //};

            //History = new ObservableCollection<HistoryItemViewModel>()
            //{
            //    new HistoryItemViewModel()
            //        { },
            //    new HistoryItemViewModel()
            //    {
            //    }
            //};
        }

        public void PrevMonth()
        {
            var month = _applicationService.GetMonth(Month.FirstDay.AddMonths(-1));
            Month = new MonthViewModel(month);
        }

        public void NextMonth()
        {
            var month = _applicationService.GetMonth(Month.FirstDay.AddMonths(1));
            Month = new MonthViewModel(month);
        }
    }
}