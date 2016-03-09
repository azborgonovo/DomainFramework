using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace DomainFramework
{
    /// <summary>
    /// Provides logic for raising and handling domain events.
    /// </summary>
    /// http://dddsamplenet.codeplex.com/SourceControl/latest#DDDSample-Vanilla/Domain/DomainEvents.cs
    public static class DomainEvents
    {
        [ThreadStatic]
        static List<Delegate> _actions;

        static List<Delegate> Actions
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

        public static void Raise<T>(T @event) where T : DomainEvent
        {
            try
            {
                var registeredHandlers = ServiceLocator.Current.GetAllInstances<IEventHandler<T>>();
                foreach (var handler in registeredHandlers)
                {
                    @event.SetNoticedDate();
                    handler.Handle(@event);
                }
            }
            catch (NullReferenceException)
            {
                // When service locator is not set, ignore it.
            }

            foreach (var action in Actions)
            {
                var typedAction = action as Action<T>;
                if (typedAction != null)
                    typedAction(@event);
            }
        }

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
    }
}
