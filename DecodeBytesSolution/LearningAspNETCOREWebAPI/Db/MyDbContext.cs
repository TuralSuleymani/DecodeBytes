using LearningAspNETCOREWebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningAspNETCOREWebAPI.Db
{
    public class MyDbContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasData(

               new Account()
               {
                   AccounType = AccounType.Main,
                   Id = 1,
                   Name = "Simple Account",
                   Number = "AC23435"
               });

            modelBuilder.Entity<Card>().HasData(

                new Card()
                {
                    Id = 1,
                    AccountId = 1,
                    ExpireDate = "03/24",
                    HolderName = "SDFds",
                    Number = "3333-4444-5555-6666"
                },
                 new Card()
                 {
                     Id = 2,
                     AccountId = 1,
                     ExpireDate = "03/25",
                     HolderName = "SDFds",
                     Number = "1122-4444-5555-6666"
                 });
            base.OnModelCreating(modelBuilder);
        }

    }
}
