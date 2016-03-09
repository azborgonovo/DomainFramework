using System;
using System.Threading.Tasks;

namespace DomainFramework.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Rollback();
    }
}
