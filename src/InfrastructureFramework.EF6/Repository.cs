using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.EF6
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        readonly IDbSetFactory _dbSetFactory;

        public Repository(IDbSetFactory dbSetFactory)
        {
            _dbSetFactory = dbSetFactory;
        }

        public abstract T Get(Func<T, bool> predicate);
        public abstract IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        public abstract void Add(T entity);
        public abstract void Remove(object id);
        public abstract void Update(T entity);
    }
}
