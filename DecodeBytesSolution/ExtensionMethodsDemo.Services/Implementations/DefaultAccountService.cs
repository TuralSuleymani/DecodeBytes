using ExtensionMethodsDemo.Common;
using ExtensionMethodsDemo.Services.Contracts;

namespace ExtensionMethodsDemo.Services.Implementations
{
    public class DefaultAccountService : IAccountService
    {
        public Task<Account?> GetAccountByIdAsync(Guid accountId)
        {
            return Task.FromResult(new Account("43544355", true, null))!;
        }

        public Task<IEnumerable<Account>> GetAllAccountsAsync()
        {
            List<Account> accounts = new List<Account>()
            {
                 new Account("11223445",true, null),
                 new Account("4355664",false,Guid.NewGuid())
            };
            return Task.FromResult(accounts.AsEnumerable());
        }
    }
}
