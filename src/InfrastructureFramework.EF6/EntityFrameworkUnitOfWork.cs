using CommonUnitOfWork;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InfrastructureFramework.EF6
{
    public class EntityFrameworkUnitOfWork : IUnitOfWork
    {
        bool _usesDatabaseTransaction;
        DbContext _dbContext;
        DbContextTransaction _dbContextTransaction;

        public EntityFrameworkUnitOfWork(DbContext dbContext, bool beginTransaction)
        {
            _dbContext = dbContext;
            _usesDatabaseTransaction = beginTransaction;
            if (_usesDatabaseTransaction)
                _dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
            if (_usesDatabaseTransaction && _dbContextTransaction != null)
                _dbContextTransaction.Commit();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
            if (_usesDatabaseTransaction && _dbContextTransaction != null)
                _dbContextTransaction.Commit();
        }

        public void Rollback()
        {
            if (_usesDatabaseTransaction && _dbContextTransaction != null)
                _dbContextTransaction.Rollback();
        }

        public void Dispose()
        {
            if (_dbContextTransaction != null)
                _dbContextTransaction.Dispose();
        }
    }
}
