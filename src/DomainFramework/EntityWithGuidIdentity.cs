using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework
{
    public abstract class EntityWithGuidIdentity : Entity<string>
    {
        public EntityWithGuidIdentity()
        {
            Id = Guid.NewGuid().ToString();
        }

        public EntityWithGuidIdentity(string id)
        {
            Id = id;
        }
    }
}
