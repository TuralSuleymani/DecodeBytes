using LearningAspNETCOREWebAPI.Data;
using LearningAspNETCOREWebAPI.Models;
using LearningAspNETCOREWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LearningAspNETCOREWebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController : ControllerBase
    {
        private readonly TransactionService _transactionService;
        public AccountsController(TransactionService transactionService)
        {
            _transactionService = transactionService;
        }

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
