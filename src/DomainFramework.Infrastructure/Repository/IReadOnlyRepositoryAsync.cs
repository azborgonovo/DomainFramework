using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainFramework
{
    public interface IReadOnlyRepositoryAsync<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(Func<T, bool> predicate = null);
        Task<T> Get(Func<T, bool> predicate);
    }
}
