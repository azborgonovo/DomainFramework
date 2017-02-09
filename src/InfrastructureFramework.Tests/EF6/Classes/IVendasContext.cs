using CommonUnitOfWork;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public interface IVendasContext : IUnitOfWorkFactory<IVendasUnitOfWork>
    {
    }
}
