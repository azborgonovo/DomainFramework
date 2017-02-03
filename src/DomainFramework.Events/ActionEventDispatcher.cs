using System;
using System.Collections.Generic;

namespace DomainFramework.Events
{
    public class ActionEventDispatcher : EventDispatcherBase
    {
        [ThreadStatic]
        private static List<Delegate> _actions;

        private static List<Delegate> Actions
        {
            get
            {
                if (_actions == null)
                    _actions = new List<Delegate>();

                return _actions;
            }
        }

        public static IDisposable Register<T>(Action<T> callback)
        {
            Actions.Add(callback);
            return new DomainEventRegistrationRemover(() => Actions.Remove(callback));
        }

        protected override IEnumerable<IEventHandler<T>> GetEventHandlers<T>()
        {
            foreach (var action in Actions)
            {
                var typedAction = action as Action<T>;
                if (typedAction != null)
                    yield return new ActionEventHandler<T>(typedAction);
            }
        }

        #region Private classes

        private sealed class DomainEventRegistrationRemover : IDisposable
        {
            readonly Action _callOnDispose;

            public DomainEventRegistrationRemover(Action toCall)
            {
                _callOnDispose = toCall;
            }

            public void Dispose()
            {
                _callOnDispose();
            }
        }

        private sealed class ActionEventHandler<T> : IEventHandler<T>
        {
            readonly Action<T> _action;

            public ActionEventHandler(Action<T> action)
            {
                _action = action;
            }

            public void Handle(T @event)
            {
                _action(@event);
            }
        }

        #endregion
    }
}
