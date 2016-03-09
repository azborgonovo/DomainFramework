using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework
{
    public abstract class Entity<TIdentity> : IEntity<TIdentity>
    {
        public TIdentity Id
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
