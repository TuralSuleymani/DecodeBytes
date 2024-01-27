using Microsoft.EntityFrameworkCore;
using ReportAPI.Models;

namespace ReportAPI.Database
{
    public class ReportDbContext:DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }
        public DbSet<EmployeeReport> Reports { get; set; }
    }
}
