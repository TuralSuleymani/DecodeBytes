using Microsoft.EntityFrameworkCore;

namespace EfCoreWithScalarFunctionsAPI.Database
{
    public class AdventureWorksDbContext : DbContext
    {
        public DbSet<SalesOrderDetail> SalesOrderDetails { get; set; }
        public decimal GetTotalUnitPriceBySpecialOfferId(int salesOfferId)
            => throw new System.NotImplementedException();

        public AdventureWorksDbContext(DbContextOptions<AdventureWorksDbContext> dbContextOptions)
            : base(dbContextOptions) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDbFunction(typeof(AdventureWorksDbContext)
                .GetMethod(nameof(GetTotalUnitPriceBySpecialOfferId), new[] { typeof(int) }))
                .HasName("ufn_GetTotalUnitPriceBySalesOfferId");

            base.OnModelCreating(modelBuilder);
        }

    }
}
