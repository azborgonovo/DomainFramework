using InfrastructureFramework.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class CoreUnitOfWork : EntityFrameworkUnitOfWork, ICoreUnitOfWork
    {
        readonly Func<IUsersRepository> _usersRepository;

        public IUsersRepository UsersRepository { get { return new UsersRepository(this); } }

        public CoreUnitOfWork() : base() { }

        public CoreUnitOfWork(bool beginTransaction) : base(beginTransaction) { }
    }
}
