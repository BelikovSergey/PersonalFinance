using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Entities;

namespace PersonalFinance.ViewModels
{
    class HistoryItemViewModel
    {
        public Transaction Transaction { get; }

        public HistoryItemViewModel(Transaction transaction)
        {
            Transaction = transaction;
        }
    }
}
