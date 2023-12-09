using ExtensionMethodsDemo.Common;

namespace ExtensionMethodsDemo.Services.Contracts
{
    public interface IAccountService
    {
        Task<Account?> GetAccountByIdAsync(Guid accountId);
        Task<IEnumerable<Account>> GetAllAccountsAsync();
    }
}
