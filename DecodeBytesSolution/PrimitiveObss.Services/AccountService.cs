using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrimitiveObss.Services
{

    public class AccountService : IAccountService
    {
        public async Task<Account> CreateAccount(Account account)
        {
            return await Task.FromResult(account);
        }
    }
}
