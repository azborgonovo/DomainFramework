using System;
using System.Collections.Generic;

namespace DomainFramework.EventHandling
{
    public abstract class EventDispatcherBase : IEventDispatcher
    {
        public virtual void Dispatch<T>(T @event)
        {
            var registeredHandlers = GetEventHandlers<T>();
            var domainEvent = @event as DomainEvent;
            if (domainEvent != null)
                domainEvent.SetDispatchedDate();

            foreach (var handler in registeredHandlers)
            {
                handler.Handle(@event);
            }
        }

        protected abstract IEnumerable<IEventHandler<T>> GetEventHandlers<T>();
    }
}
