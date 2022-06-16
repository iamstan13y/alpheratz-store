using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;

namespace Alpheratz.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Category = new CategoryRepository(context);
        }

        public void Save() => _context.SaveChanges();
    }
}