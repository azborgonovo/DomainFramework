using CommonUnitOfWork;
using InfrastructureFramework.EF6;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class VendasContext : IUnitOfWorkFactory<IVendasUnitOfWork>
    {
        public IVendasUnitOfWork CreateUnitOfWork()
        {
            return ServiceLocator.Current.GetInstance<IVendasUnitOfWork>();
        }

        public IVendasUnitOfWork CreateUnitOfWork(bool beginTransaction)
        {
            // TODO: We need to override parameter "beginTransaction"
            return ServiceLocator.Current.GetInstance<IVendasUnitOfWork>();
        }
    }
}
