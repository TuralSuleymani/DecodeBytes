using ExpressionTreesInPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpressionTreesInPractice.Database
{
    public class ProductDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new List<Product>
            {
                new Product(){ Id = 1, Category = "TV", IsActive = true, Name = "LG", Price = 500},
                new Product(){ Id = 2, Category = "Mobile", IsActive = false, Name = "Iphone", Price = 4500},
                new Product(){ Id = 3, Category = "TV", IsActive = true, Name = "Samsung", Price = 2500}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
