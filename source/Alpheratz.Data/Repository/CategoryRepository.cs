using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context) => _context = context;
        
        public void Update(Category category) => _context.Update(category);
    }
}