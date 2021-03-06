﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework.Events
{
    /// <summary>
    /// http://benfoster.io/blog/deferred-domain-events
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Handles the event.
        /// </summary>
        /// <param name="event">Event object.</param>
        void Dispatch<T>(T @event) where T : DomainEvent;
    }
}
