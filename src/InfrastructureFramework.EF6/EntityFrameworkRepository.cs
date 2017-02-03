using System;
using System.Collections.Generic;

namespace InfrastructureFramework.EF6
{
    public class EntityFrameworkRepository<T> : RepositoryBase<T> where T : class
    {
        public EntityFrameworkRepository(IDbSetFactory dbSetFactory) : base(dbSetFactory)
        {
        }

        public override void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public override T Get(Func<T, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            throw new NotImplementedException();
        }

        public override void Remove(object id)
        {
            throw new NotImplementedException();
        }

        public override void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
