using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}