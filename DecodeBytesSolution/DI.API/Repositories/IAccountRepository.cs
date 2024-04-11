using DI.API.Models;

namespace DI.API.Repositories
{
    public interface IAccountRepository
    {
        Task<Account?> GetAccountByIdAsync(Guid accountId);
        Task<List<Account>> GetAccountsAsync();
    }
}