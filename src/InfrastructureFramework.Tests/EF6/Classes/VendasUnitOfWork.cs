using InfrastructureFramework.EF6;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class VendasUnitOfWork : EntityFrameworkUnitOfWork, IVendasUnitOfWork
    {
        public IUsuariosRepository UsuariosRepository { get { return new UsuariosRepository(this); } }
        // public IUsuariosRepository UsuariosRepository { get { return new UsuariosRepository(this); } }

        public VendasUnitOfWork() : base() { }

        public VendasUnitOfWork(bool beginTransaction) : base(beginTransaction) { }
    }
}
