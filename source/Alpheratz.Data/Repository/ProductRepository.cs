using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context) : base(context) => _context = context;

        public void Update(Product product)
        {
            var productFromDb = _context.Products!.FirstOrDefault(u => u.Id == product.Id);
            if(productFromDb != null)
            {
                productFromDb.CategoryId = product.CategoryId;
                productFromDb.CoverTypeId = product.CoverTypeId;
                productFromDb.Price100 = product.Price100;  
                productFromDb.Description = product.Description;
                productFromDb.Price50 = product.Price50;
                productFromDb.ISBN = product.ISBN;
                productFromDb.ListPrice = product.ListPrice;
                productFromDb.Price = product.Price;
                productFromDb.Title = product.Title;
                if (product.ImageUrl != null)
                    productFromDb.ImageUrl = product.ImageUrl;
            }
        }
    }
}