using EmployeeApplicationAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplicationAPI.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> dbContextOptions)
            :base(dbContextOptions)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
