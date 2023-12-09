using ExtensionMethodsDemo.Common;
using ExtensionMethodsDemo.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using ExtensionMethodsDemo.Services.Extensions;
using System.Security.Principal;

namespace ExtensionMethodsDemo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private IAccountService _accountService;
        public AccountController(ILogger<AccountController> logger,
            IAccountService accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }

        [HttpGet("active")]
        public async Task<IEnumerable<Account>> GetActiveAccounts()
        {
            return await _accountService.GetActiveAccountsAsync(x => x.IsDisabled != false);
        }

        [HttpGet("active/{parentId:Guid}")]
        public async Task<IEnumerable<Account>> GetActiveAccountsByParentId(Guid parentId)
        {
            return await _accountService.GetActiveAccountsAsync(x => x.IsDisabled != false && x.RootAccountId == parentId);
        }

        //should be reusable accoss the domain models
        [HttpGet("csv")]
        public async Task<string?> GetAsCsv()
        {
            return await _accountService.AsCsvAsync();

        }
    }
}