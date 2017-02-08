namespace CommonUnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
        IUnitOfWork CreateUnitOfWork(bool beginTransaction);
    }
}