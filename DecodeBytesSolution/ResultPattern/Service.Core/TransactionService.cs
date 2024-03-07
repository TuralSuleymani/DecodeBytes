using Domain.Models;
using Service.Abstaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Core
{
    internal class TransactionService : ITransactionService
    {
        private readonly IAccountServiceV2 _accountService;
        public TransactionService(IAccountServiceV2 accountService)
        {
            _accountService = accountService;
        }
        public async Task<bool> ProcessAsync(Account account)
        {
            throw new NotImplementedException();
            //var accountResponse = await _accountService.AddAsync(account);
            //if (accountResponse.IsSuccess)
            //{
            //    Account MyAccount = accountResponse.Value;
            //}

            //if (accountResponse.IsFailure)
            //{
            //    string errorMessage = accountResponse.Error.ErrorMessage;
            //}
        }
    }
}
