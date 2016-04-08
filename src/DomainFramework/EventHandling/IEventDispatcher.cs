namespace DomainFramework.EventHandling
{
    /// <summary>
    /// http://benfoster.io/blog/deferred-domain-events
    /// </summary>
    public interface IEventDispatcher
    {
        /// <summary>
        /// Dipatch an event to related registered event handlers
        /// </summary>
        /// <param name="event">Event object.</param>
        void Dispatch<T>(T @event);
    }
}
