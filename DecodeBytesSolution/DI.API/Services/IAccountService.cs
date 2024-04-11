using CSharpFunctionalExtensions;
using DI.API.Models;

namespace DI.API.Services
{
    public interface IAccountService
    {
        Task<Result<Account, string>> Bind(Guid accountId, Guid cardId);
        Task<List<Account>> GetAllAsync();
    }
}