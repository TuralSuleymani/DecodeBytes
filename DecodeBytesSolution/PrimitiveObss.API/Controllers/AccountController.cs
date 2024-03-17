using Microsoft.AspNetCore.Mvc;
using PrimitiveObss.Services;
using System.ComponentModel.DataAnnotations;

namespace PrimitiveObss.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost]
        public async Task<ActionResult<AccountModel>> CreateAccount(AccountModel model)
        {
           var accountNameResponse = AccountName.Create(model.Name);
            if(accountNameResponse.IsFailure)
            {
                ModelState.AddModelError("Name", accountNameResponse.Error);
            }

            var accountNumberResponse = AccountNumber.Create(model.Number);
            if (accountNumberResponse.IsFailure)
            {
                ModelState.AddModelError("number", accountNumberResponse.Error);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var account = new Account(accountNameResponse.Value,accountNumberResponse.Value);
            var response = await _accountService.CreateAccount(account);

            string accountName = accountNameResponse.Value;
            string accountNumber = accountNumberResponse.Value;

            var userResponse = new AccountModel() { Name = accountName, Number = accountNumber };
            return CreatedAtAction(nameof(CreateAccount), userResponse);
        }
    }

    public class AccountModel
    {
        public string Name { get; set; }

        public string Number { get; set; }

    }
}
