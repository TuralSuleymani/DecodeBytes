using LearningAspNETCOREWebAPI.Data;
using LearningAspNETCOREWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace LearningAspNETCOREWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Account> GetAccounts()
        {
            return AccountDbContext.Current.Accounts;
        }

        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
           var account =  AccountDbContext.Current.Accounts.FirstOrDefault(x => x.Id == id);
            if(account is null)
            {
                return BadRequest();
            }
            return Ok(account);
        }
    }
}
