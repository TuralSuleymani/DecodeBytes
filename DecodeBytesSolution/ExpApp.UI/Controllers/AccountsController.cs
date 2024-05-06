using ExpApp.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExpApp.Services;
namespace ExpApp.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly AccountService _accountService;
        public AccountsController()
        {
            _accountService = new AccountService();
        }
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccountById(int id)
        {
           var account = _accountService.GetAccountById(id);
            if(account.IsSuccess)
            {
                return Ok(account.Value);
            }
            else
            {
                return BadRequest(account.Error);
            }
        }
    }
}
