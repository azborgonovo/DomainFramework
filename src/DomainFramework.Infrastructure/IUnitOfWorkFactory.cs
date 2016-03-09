namespace DomainFramework.Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
        IUnitOfWork CreateUnitOfWork(bool beginDatabaseTransaction);
    }
}
