using CommonUnitOfWork;
using InfrastructureFramework.EF6;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public interface ICoreUnitOfWork : IUnitOfWork, IDbSetFactory
    {
        IUsersRepository UsersRepository { get; }
    }
}
