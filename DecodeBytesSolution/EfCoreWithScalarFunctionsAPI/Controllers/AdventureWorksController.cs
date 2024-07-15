using EfCoreWithScalarFunctionsAPI.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EfCoreWithScalarFunctionsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdventureWorksController : ControllerBase
    {
        private readonly AdventureWorksDbContext _adventureWorksDbContext;
        public AdventureWorksController(AdventureWorksDbContext adventureWorksDbContext)
        {
            _adventureWorksDbContext = adventureWorksDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SalesOrderDetail>>> GetSalesOrderInformationAsync()
        {
            var response = await (from sod in _adventureWorksDbContext.SalesOrderDetails
                                  where _adventureWorksDbContext.GetTotalUnitPriceBySpecialOfferId(sod.SpecialOfferId) > 10_000
                                  select sod).Take(10)
                           .ToListAsync();

            return Ok(response);

        }
    }
}
