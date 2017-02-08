using CommonUnitOfWork;
using InfrastructureFramework.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class CoreContext : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new CoreUnitOfWork();
        }

        public IUnitOfWork CreateUnitOfWork(bool beginTransaction)
        {
            return new CoreUnitOfWork(beginTransaction);
        }
    }
}
