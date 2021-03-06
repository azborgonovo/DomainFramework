﻿using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;

namespace DomainFramework.Events
{
    /// <summary>
    /// Provides logic for raising and handling domain events.
    /// </summary>
    /// http://dddsamplenet.codeplex.com/SourceControl/latest#DDDSample-Vanilla/Domain/DomainEvents.cs
    public static class DomainEvents
    {
        [ThreadStatic]
        static List<Delegate> _actions;

        static IEventDispatcher _eventDispatcher;

        static List<Delegate> Actions
        {
            get
            {
                if (_actions == null)
                    _actions = new List<Delegate>();

                return _actions;
            }
        }

        static DomainEvents()
        {
            _eventDispatcher = new CommonServiceLocatorEventDispatcher();
        }

        public static IDisposable Register<T>(Action<T> callback)
        {
            Actions.Add(callback);
            return new DomainEventRegistrationRemover(() => Actions.Remove(callback));
        }

        public static void SetEventDispatcher(IEventDispatcher eventDispatcher)
        {
            _eventDispatcher = eventDispatcher;
        }

        public static void Raise<T>(T @event) where T : DomainEvent
        {
            _eventDispatcher.Dispatch(@event);

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
