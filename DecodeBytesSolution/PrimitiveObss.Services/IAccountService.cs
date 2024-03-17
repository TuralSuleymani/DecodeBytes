
namespace PrimitiveObss.Services
{
    public interface IAccountService
    {
        Task<Account> CreateAccount(Account account);
    }
}