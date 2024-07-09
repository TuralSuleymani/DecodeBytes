using Microsoft.EntityFrameworkCore;
namespace EFCOreWithSP.Database
{
    internal class ShoppingDbContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=ShoppingDb;TrustServerCertificate=TRUE;Integrated Security=SSPI;Trusted_Connection=True;");
        }
    }
}
