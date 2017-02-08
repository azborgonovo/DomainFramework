using InfrastructureFramework.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class UsersRepository : EntityFrameworkRepositoryBase<User>, IUsersRepository
    {
        public UsersRepository(ICoreUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
