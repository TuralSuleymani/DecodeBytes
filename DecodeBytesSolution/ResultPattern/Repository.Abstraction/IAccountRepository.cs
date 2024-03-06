
namespace Repository.Abstraction
{
    public interface IAccountRepository
    {
        Task<bool> IsExistsAsync(string accountNumber);
    }
}
