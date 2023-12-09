using Microsoft.EntityFrameworkCore;

namespace CsharpDelegates.Database.Models
{
    public class CustomerAppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Card> Cards { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.LogTo(message => Console.WriteLine(message));
            optionsBuilder.UseSqlServer(@"Data Source=.\;Initial Catalog=CustomerDb;Integrated Security=SSPI;TrustServerCertificate=True;MultipleActiveResultSets=true");
        }
    }
}
