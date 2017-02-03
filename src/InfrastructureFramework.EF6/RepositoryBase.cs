using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.EF6
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected readonly IDbSet<T> DbSet;

        public RepositoryBase(IDbSetFactory dbSetFactory)
        {
            DbSet = dbSetFactory.CreateDbSet<T>();
        }

        public abstract T Get(Func<T, bool> predicate);
        public abstract IEnumerable<T> GetAll(Func<T, bool> predicate = null);
        public abstract void Add(T entity);
        public abstract void Remove(object id);
        public abstract void Update(T entity);
    }
}
