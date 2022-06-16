using Alpheratz.ModelLibrary.Models;

namespace Alpheratz.DataAccess.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {
        void Update(Category category);
        void Save();
    }
}