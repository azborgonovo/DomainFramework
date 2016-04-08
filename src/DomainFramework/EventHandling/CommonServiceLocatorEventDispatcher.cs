//using Microsoft.Practices.ServiceLocation;
//using System.Collections.Generic;

//namespace DomainFramework.EventHandling
//{
//    public class CommonServiceLocatorEventDispatcher : EventDispatcherBase
//    {
//        protected override IEnumerable<IEventHandler<T>> GetEventHandlers<T>()
//        {
//            return ServiceLocator.Current.GetAllInstances<IEventHandler<T>>();
//        }
//    }
//}
