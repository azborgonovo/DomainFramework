using CommonUnitOfWork;
using System.Data.Entity;
using System.Threading.Tasks;
using System;

namespace InfrastructureFramework.EF6
{
    public class EntityFrameworkUnitOfWork : DbContext, IUnitOfWork, IDbSetFactory
    {
        DbContextTransaction dbContextTransaction;

        public EntityFrameworkUnitOfWork() : this(false) { }

        public EntityFrameworkUnitOfWork(bool beginTransaction) : this(null, false) { }

        public EntityFrameworkUnitOfWork(string nameOrConnectionString, bool beginTransaction)
            : base(nameOrConnectionString)
        {
            if (beginTransaction)
                dbContextTransaction = Database.BeginTransaction();
        }
        
        public void Commit()
        {
            SaveChanges();
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }

        public async Task CommitAsync()
        {
            await SaveChangesAsync();
            if (dbContextTransaction != null)
                dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Rollback();
        }

        public new void Dispose()
        {
            if (dbContextTransaction != null)
                dbContextTransaction.Dispose();

            base.Dispose();
        }

        public IDbSet<T> CreateDbSet<T>() where T : class
        {
            return Set<T>();
        }
    }
}
