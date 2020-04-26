using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalFinance.Domain.Interfaces;

namespace PersonalFinance.Domain
{
    public static class DomainEvents
    {
        private static readonly ConcurrentDictionary<Type, IEnumerable<Delegate>> _handlers = new ConcurrentDictionary<Type, IEnumerable<Delegate>>();

        public static void Register<T>(Action<T> eventHandler) where T : IDomainEvent
        {
            _handlers.AddOrUpdate(typeof(T), 
                (type)=> new List<Delegate> {eventHandler},
                (type, list) => new List<Delegate>(list) {eventHandler});
        }

        public static void Raise<T>(T domainEvent) where T : IDomainEvent
        {
            if (_handlers.TryGetValue(domainEvent.GetType(), out var subscriptions))
            {
                foreach (Delegate d in subscriptions)
                {
                    var action = (Action<T>) d;
                    action(domainEvent);
                }
            }
        }
    }
}
