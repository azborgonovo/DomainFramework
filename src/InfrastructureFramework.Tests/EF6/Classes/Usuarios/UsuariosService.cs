using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class UsuariosService
    {
        readonly IVendasUnitOfWork unitOfWork;

        public UsuariosService(IVendasUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void GetAll()
        {
            try
            {
                //var users = unitOfWork.UsersRepository.GetAll();
                //return users.Map<UserDto>();
            }
            catch (Exception)
            {
                ApplicationService.Fail();
            }
        }

        public void Add()
        {
            try
            {
                var user = new Usuario();
                // unitOfWork.UsersRepository.Add(user);
                // Commit ou Rollback deve ser feito pelo criador da UnitOfWork
            }
            catch (Exception)
            {
                ApplicationService.Fail();
            }
        }
    }
}
