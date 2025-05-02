using Microsoft.EntityFrameworkCore;
using ExcelImportApi.Models;

namespace ExcelImportApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
    }
}
