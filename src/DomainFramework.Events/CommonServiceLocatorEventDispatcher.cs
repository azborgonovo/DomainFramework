using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework.Events
{
    public class CommonServiceLocatorEventDispatcher : IEventDispatcher
    {
        public void Dispatch<T>(T @event) where T : DomainEvent
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
        }
    }
}
