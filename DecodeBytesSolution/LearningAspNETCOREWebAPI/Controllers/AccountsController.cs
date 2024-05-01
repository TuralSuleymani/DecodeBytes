
using LearningAspNETCOREWebAPI.Db;
using LearningAspNETCOREWebAPI.Entities;
using LearningAspNETCOREWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearningAspNETCOREWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly MyDbContext _dbContext;
        public AccountsController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccounts()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (account is null)
            {
                return BadRequest();
            }
            return Ok(account);
        }
    }
}
