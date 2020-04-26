using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Caliburn.Micro;
using PersonalFinance.Application;
using PersonalFinance.Domain;
using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Events;
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

                History = new ObservableCollection<HistoryItemViewModel>(
                    _month.Accounts.Select(x => x.Model)
                        .SelectMany(x => x.Transactions)
                        .OrderByDescending(x => x.Date)
                        .Select(x => new HistoryItemViewModel(x)));
            }
        }

        public IEnumerable<SpentByCategoryViewModel> Categories =>
            _month.Categories.Select(x => new SpentByCategoryViewModel(x, _month.Model));

        private SpentByCategoryViewModel _selectedCategory;

        public SpentByCategoryViewModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                NotifyOfPropertyChange();
            }
        }

        public IEnumerable<AccountViewModel> Accounts => Month.Accounts;

        private AccountViewModel _selectedAccount;

        public AccountViewModel SelectedAccount
        {
            get => _selectedAccount;
            set
            {
                _selectedAccount = value;
                NotifyOfPropertyChange();
                EnterMoney.SelectedCurrency = _selectedAccount?.Model.Currency ?? _applicationService.DefaultCurrency;
            }
        }

        private ObservableCollection<HistoryItemViewModel> _history;

        public ObservableCollection<HistoryItemViewModel> History
        {
            get => _history;
            set
            {
                _history = value;
                NotifyOfPropertyChange();
            }
        }

        public EnterMoneyViewModel EnterMoney { get; }

        public ShellViewModel(IApplicationService applicationService, EnterMoneyViewModel enterMoneyViewModel)
        {
            _applicationService = applicationService;

            DomainEvents.Register<NewTransaction>(OnNewTransaction);

            var today = DateTime.Today;

            var month = _applicationService.GetMonth(today.FirstDay());
            Month = new MonthViewModel(month);

            EnterMoney = enterMoneyViewModel;
            EnterMoney.MoneyEnteredEvent += EnterMoney_MoneyEnteredEvent;
        }

        private void EnterMoney_MoneyEnteredEvent(Domain.ValueObjects.Money moneyEntered)
        {
            SelectedAccount.Spend(DateTime.Now, moneyEntered, SelectedCategory.Model);
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

        private void OnNewTransaction(NewTransaction newTransaction)
        {
            if (newTransaction.Transaction.Date.FirstDay() == Month.FirstDay)
            {
                for (var i = 0; i < History.Count; i++)
                {
                    if (newTransaction.Transaction.Date >= History[i].Transaction.Date)
                    {
                        History.Insert(i, new HistoryItemViewModel(newTransaction.Transaction));
                        return;
                    }
                }

                History.Add(new HistoryItemViewModel(newTransaction.Transaction));
            }
        }
    }
}