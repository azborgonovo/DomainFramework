using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainFramework
{
    public interface IEntity<TIdentity>
    {
        TIdentity Id { get; }
    }
}
