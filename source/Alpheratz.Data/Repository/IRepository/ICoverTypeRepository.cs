using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository.IRepository
{
    public interface ICoverTypeRepository : IRepository<CoverType>
    {
        void Update(CoverType coverType);
    }
}