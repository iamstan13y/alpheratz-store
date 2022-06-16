using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;
using System.Linq.Expressions;

namespace Alpheratz.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _context;

        public CategoryRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public void Save() => _context.SaveChanges();

        public void Update(Category category) => _context.Update(category);
    }
}