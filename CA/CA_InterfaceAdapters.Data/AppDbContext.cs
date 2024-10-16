using CA_InterfaceAdapters.Models;
using Microsoft.EntityFrameworkCore;

namespace CA_InterfaceAdapters.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        { }

        public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductModel>();
        }
    }
}
