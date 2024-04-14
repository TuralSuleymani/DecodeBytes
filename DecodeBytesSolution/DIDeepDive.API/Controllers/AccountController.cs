using DIDeepDive.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace DIDeepDive.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController(AccountNumberService accountNumberService,TransactionService transactionService) : ControllerBase
    {
        private readonly AccountNumberService _accountNumberService = accountNumberService;
        private readonly TransactionService _transactionService = transactionService;
        public string Get()
        { 
            return $"{_accountNumberService.GetAccountNumber()} {_transactionService.GetAccountNumber()}";
        }
    }
}
