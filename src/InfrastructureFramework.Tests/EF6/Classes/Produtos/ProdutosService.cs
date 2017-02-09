using CommonUnitOfWork;
using System;

namespace InfrastructureFramework.Tests.EF6.Classes
{
    public class ProdutosService
    {
        readonly IVendasContext vendasContext;

        public ProdutosService(IVendasContext vendasContext)
        {
            this.vendasContext = vendasContext;
        }

        public void GetAllProducts()
        {
            try
            {
                using (var unitOfWork = vendasContext.CreateUnitOfWork())
                {
                    var product = new Produto();
                    // var products = unitOfWork.ProductsRepository.GetAll();
                }
            }
            catch (Exception ex)
            {
                ApplicationService.Fail(ex);
            }
        }

        public void AddProduct()
        {
            try
            {
                using (var unitOfWork = vendasContext.CreateUnitOfWork())
                {
                    try
                    {
                        var product = new Produto();
                        // unitOfWork.ProdutosRepository.Add(product);                
                        unitOfWork.Commit();
                    }
                    catch
                    {
                        unitOfWork.Rollback();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                ApplicationService.Fail(ex);
            }
        }
    }
}
