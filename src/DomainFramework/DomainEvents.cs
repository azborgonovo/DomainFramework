using DomainFramework.EventHandling;

namespace DomainFramework
{
    /// <summary>
    /// Provides logic for raising domain events.
    /// </summary>
    /// http://dddsamplenet.codeplex.com/SourceControl/latest#DDDSample-Vanilla/Domain/DomainEvents.cs
    public static class DomainEvents
    {
        public static IEventDispatcher EventDispatcher { get; set; }

        static DomainEvents()
        {
            // EventDispatcher = new CommonServiceLocatorEventDispatcher();
        }

        public static void Raise<T>(T @event)
        {
            if (@event != null)
            {
                EventDispatcher.Dispatch(@event);
            }
        }
    }
}
