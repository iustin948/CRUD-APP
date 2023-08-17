using APP.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace APP.DataAcces.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public  DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Chitara", Description = "Very Good", Price = 100 },
                new Product { Id = 2, Name = "Chitara", Description = "Very Good", Price = 100 },
                new Product { Id = 3, Name = "Chitara", Description = "Very Good", Price = 100 }


                ); 
        }
    }
}
