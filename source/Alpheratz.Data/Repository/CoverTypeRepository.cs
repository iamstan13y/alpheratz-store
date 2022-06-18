using Alpheratz.DataAccess.Data;
using Alpheratz.DataAccess.Repository.IRepository;
using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly AppDbContext _context;

        public CoverTypeRepository(AppDbContext context) : base(context) => _context = context;

        public void Update(CoverType coverType)
        {
            throw new NotImplementedException();
        }
    }
}