using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Domain
{
    public static class DomainEvents
    {
        private static readonly Dictionary<Type, List<Delegate>> _handlers = new Dictionary<Type, List<Delegate>>();

        public static void Register<T>(Action<T> eventHandler) where T : IDomainEvent
        {
            _handlers[typeof(T)].Add(eventHandler);
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            foreach (Delegate d in _handlers[domainEvent.GetType()])
            {
                var action = (Action<T>) d;
                action(domainEvent);
            }
        }
    }
}
