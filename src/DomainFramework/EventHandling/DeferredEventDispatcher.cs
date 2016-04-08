using System;
using System.Collections.Concurrent;

namespace DomainFramework.EventHandling
{
    public class DeferredEventDispatcher : IEventDispatcher
    {
        readonly IEventDispatcher _inner;
        readonly ConcurrentQueue<Action> _events = new ConcurrentQueue<Action>();

        public DeferredEventDispatcher(IEventDispatcher inner)
        {
            _inner = inner;
        }

        public void Dispatch<T>(T @event)
        {
            _events.Enqueue(() => InnerDispatch(@event));
        }

        private void InnerDispatch<T>(T @event)
        {
            var domainEvent = @event as DomainEvent;
            if (@event != null)
                domainEvent.SetDispatchedDate();

            _inner.Dispatch(@event);
        }

        public void Resolve()
        {
            Action dispatch;
            while (_events.TryDequeue(out dispatch))
            {
                dispatch();
            }
        }
    }
}
