using EmployeeApplicationAPI.Database;
using EmployeeApplicationAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController(EmployeeDbContext dbContext, ILogger<EmployeesController> logger) : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger = logger;
        private readonly EmployeeDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            _logger.LogInformation("Requesting all employees");
            return await _dbContext.Employees.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(string name, string surname)
        {
            var employee = new Employee(Guid.NewGuid(), name, surname);
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateEmployee), new { id = employee.Id }, employee);
        }
    }
}
