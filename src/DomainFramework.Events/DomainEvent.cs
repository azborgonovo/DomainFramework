using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework
{
    /// <summary>
    /// Base class for all domain events.
    /// </summary>
    /// <remarks>
    /// As Udi Dahan says "Events that pass between bounded contexts should indeed only contain IDs. Domain events that occur within a single bounded context should contain the full entity as upstream handlers may need the additional information to make decisions within that same bounded context."
    /// http://udidahan.com/2009/06/14/domain-events-salvation/
    /// </remarks>
    public abstract class DomainEvent
    {
        private readonly DateTime _dateOcurred;
        private DateTime _dateNoticed;

        protected DomainEvent()
        {
            _dateOcurred = DateTime.Now;
        }
        
        public DateTime Ocurred
        {
            get
            {
                return _dateOcurred;
            }
        }

        public DateTime Noticed
        {
            get
            {
                return _dateNoticed;
            }
        }

        public void SetNoticedDate()
        {
            if (_dateNoticed == null || _dateNoticed == default(DateTime))
                _dateNoticed = DateTime.Now;
            else
                throw new InvalidOperationException("The noticed date of this event was already been set.");
        }
    }
}
