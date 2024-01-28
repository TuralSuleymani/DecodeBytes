using Consumer.Database.ReportAPI.Database;
using Consumer.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Consumer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController(ReportDbContext dbContext,ILogger<ReportController> logger) : ControllerBase
    {
        private readonly ILogger<ReportController> _logger = logger;
        private readonly ReportDbContext _dbContext = dbContext;

        [HttpGet(Name = "GetReports")]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await _dbContext.Reports.Select(x => new Employee()
            {
                Id = x.Id,
                Name = x.Name,
                Surname = x.Surname,
            }).ToListAsync();
        }
    }
}
