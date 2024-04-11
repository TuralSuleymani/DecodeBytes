using DI.API.Models;

namespace DI.API.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private static List<Account> _accounts;
        public AccountRepository()
        {
            _accounts = new List<Account>()
            {
                new Account(Guid.NewGuid(),"Account1",Guid.NewGuid()),
                new Account(Guid.Parse("49ca57e8-62f3-4da5-bc3d-1dd36907c283"),"Account1",Guid.Parse("59ca57e8-62f3-4da5-bc3d-1dd36907c283")),
            };
        }
        public Task<Account?> GetAccountByIdAsync(Guid accountId)
        {
            return Task.FromResult(_accounts.Find(x => x.AccountId == accountId));
        }

        public Task<List<Account>> GetAccountsAsync()
        {
            return Task.FromResult(_accounts);
        }
    }
}
