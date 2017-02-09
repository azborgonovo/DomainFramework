﻿using InfrastructureFramework.EF6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class UsuariosRepository : EntityFrameworkRepositoryBase<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(IVendasUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}