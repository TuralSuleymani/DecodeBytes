using LearningAspNETCOREWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningAspNETCOREWebAPI.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) { }
    }
}
