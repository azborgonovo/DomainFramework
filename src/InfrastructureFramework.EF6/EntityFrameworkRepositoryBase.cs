using System.Data.Entity;

namespace InfrastructureFramework.EF6
{
    public abstract class EntityFrameworkRepositoryBase<T> where T : class
    {
        protected readonly IDbSet<T> DbSet;

        public EntityFrameworkRepositoryBase(IDbSetFactory dbSetFactory)
        {
            DbSet = dbSetFactory.CreateDbSet<T>();
        }
    }
}