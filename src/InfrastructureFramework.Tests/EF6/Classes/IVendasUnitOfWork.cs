using CommonUnitOfWork;
using InfrastructureFramework.EF6;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public interface IVendasUnitOfWork : IUnitOfWork, IDbSetFactory
    {
        IUsuariosRepository UsuariosRepository { get; }
        // IProductsRepository ProductsRepository { get; }
    }
}
