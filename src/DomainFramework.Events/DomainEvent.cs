using System;

namespace DomainFramework.Events
{
    /// <summary>
    /// Base class for all domain events
    /// </summary>
    /// <remarks>
    /// Udi Dahan suggests that "Events that pass between bounded contexts should indeed only contain IDs.
    /// Domain events that occur within a single bounded context should contain the full entity as upstream
    /// handlers may need the additional information to make decisions within that same bounded context."
    /// See http://udidahan.com/2009/06/14/domain-events-salvation/ for more information
    /// </remarks>
    public abstract class DomainEvent
    {
        readonly DateTime _occurredDate;
        private DateTime _dispatchedDate;

        protected DomainEvent() : this(DateTime.Now)
        {
        }

        protected DomainEvent(DateTime ocurredDate)
        {
            _occurredDate = ocurredDate;
        }

        /// <summary>
        /// The Time Point when the event occurred (was created)
        /// </summary>
        public DateTime OccurredDate { get { return _occurredDate; } }

        /// <summary>
        /// The Time Point right before the event has been dispatched to the event handler
        /// </summary>
        public DateTime DispatchedDate { get { return _dispatchedDate; } }

        /// <summary>
        /// Set the dispatched date of the event
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throwed when the dispatched date is already setted</exception>
        /// <param name="date">The date the event is being dispatched</param>
        public void SetDispatchedDate(DateTime date)
        {
            if (_dispatchedDate != null)
                throw new InvalidOperationException("The dispatched date of the event is already setted.");

            _dispatchedDate = date;
        }

        /// <summary>
        /// Set the dispatched date of the event with the current date time
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Throwed when the dispatched date is already setted</exception>
        /// <param name="date"></param>
        public void SetDispatchedDate()
        {
            SetDispatchedDate(DateTime.Now);
        }
    }
}
