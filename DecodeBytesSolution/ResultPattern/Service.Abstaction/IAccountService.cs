using CSharpFunctionalExtensions;
using Domain.Models;

namespace Service.Abstaction
{
    public interface IAccountService
    {
        Task<Account> AddAsync(Account account);
        Task<Account> GetByIdAsync(Guid id);
    }

    public interface IAccountServiceV2
    {
        Task<IResult<Account, DomainError>> AddAsync(Account account);
        Task<Result<Account, DomainError>> GetByIdAsync(Guid id);
    }
}
