using System;
using System.Collections.Generic;

namespace DomainFramework
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        T Get(Func<T, bool> predicate);
    }
}
