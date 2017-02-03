using System;
using System.Threading.Tasks;

namespace CommonUnitOfWork
{
    /// <summary>
    /// Basic unitOfWork pattern as described by Martin Fowler (http://martinfowler.com/eaaCatalog/unitOfWork.html)
    /// Other methos as 'registerNew' are going to be managed by each repository 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Rollback();
    }
}