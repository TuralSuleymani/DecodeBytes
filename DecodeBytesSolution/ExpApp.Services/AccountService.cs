using CSharpFunctionalExtensions;
using ExpApp.DataAccess;
using ExpApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpApp.Services
{
    public class AccountService
    {
        private AccountRepository _accountRepository;
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public IResult<Account,string> GetAccountById(int id)
        {
            Account account = _accountRepository.GetAccountById(id);
            if(account is null)
            {
                return Result.Failure<Account, string>("We couldn't find account information you provided");
            }
            
            return Result.Success<Account,string>(account);
        }
    }
}
