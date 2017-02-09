using System;
using System.Threading.Tasks;

namespace CommonUnitOfWork
{
    /// <summary>
    /// Basic UnitOfWork pattern as described by Martin Fowler (http://martinfowler.com/eaaCatalog/unitOfWork.html)
    /// Other methods (as registerNew) are managed by each repository 
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task CommitAsync();
        void Rollback();
    }
}