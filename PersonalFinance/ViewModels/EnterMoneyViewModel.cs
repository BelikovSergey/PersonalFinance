using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using PersonalFinance.Application;
using PersonalFinance.Domain.Interfaces;
using PersonalFinance.Domain.ValueObjects;
using Action = System.Action;

namespace PersonalFinance.ViewModels
{
    class EnterMoneyViewModel : PropertyChangedBase
    {
        private readonly IApplicationService _applicationService;

        public event Action<Money> MoneyEnteredEvent;

        private decimal _amount;

        public decimal Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                NotifyOfPropertyChange();
            }
        }

        public IEnumerable<Currency> Currencies => _applicationService.Currencies;

        private Currency _selectedCurrency;

        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                NotifyOfPropertyChange();
            }
        }

        public EnterMoneyViewModel(IApplicationService applicationService)
        {
            _applicationService = applicationService;
            _selectedCurrency = _applicationService.DefaultCurrency;
        }

        public void Accept()
        {
            MoneyEnteredEvent?.Invoke(new Money(_amount, SelectedCurrency));
            Amount = 0;
        }

        public void Cancel()
        {
            Amount = 0;
            SelectedCurrency = _applicationService.DefaultCurrency;
        }
    }
}
