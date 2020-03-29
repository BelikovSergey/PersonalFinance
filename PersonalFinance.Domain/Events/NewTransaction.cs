using PersonalFinance.Domain.Entities;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Domain.Events
{
    public class NewTransaction : IDomainEvent
    {
        public Transaction Transaction { get; internal set; }
    }
}
