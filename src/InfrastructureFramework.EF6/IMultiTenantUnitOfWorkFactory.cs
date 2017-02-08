using CommonUnitOfWork;

namespace InfrastructureFramework.EF6
{
    public interface IMultiTenantUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork(Tenant tenant);
        IUnitOfWork CreateUnitOfWork(Tenant tenant, bool beginTransaction);
    }
}