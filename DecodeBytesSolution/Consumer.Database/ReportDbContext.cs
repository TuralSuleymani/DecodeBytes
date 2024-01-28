namespace Consumer.Database
{
    using Consumer.Database.Entities;
    using Microsoft.EntityFrameworkCore;
    namespace ReportAPI.Database
    {
        public class ReportDbContext : DbContext
        {
            public ReportDbContext(DbContextOptions<ReportDbContext> dbContextOptions)
                : base(dbContextOptions)
            {

            }
            public DbSet<EmployeeReport> Reports { get; set; }
        }
    }
}
