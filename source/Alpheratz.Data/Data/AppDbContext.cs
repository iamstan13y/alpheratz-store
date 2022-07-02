using Alpheratz.ModelLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace Alpheratz.DataAccess.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<CoverType>? CoverTypes { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}