using Common.Repository;
using CSharpFunctionalExtensions;
using Domain.Models;
using Repository.Abstraction;
using Service.Abstaction;

namespace Service.Core
{
    public class AccountServiceV2(
             ICustomerService customerService
           , IAccountRepository accountRepository
           , IUnitOfWork unitOfWork) : IAccountServiceV2
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<IResult<Account, DomainError>> AddAsync(Account account)
        {
            bool isCustomerExist = await _customerService.IsExistsAsync(account.CustomerId);
            if (!isCustomerExist)
            {
                return Result.Failure<Account, DomainError>(DomainError.NotFound("Customer with given Id doesn't exist"));
            }
            else
            {
                bool isAccountExist = await _accountRepository.IsExistsAsync(account.AccountNumber);
                if (isAccountExist)
                {
                    await _unitOfWork.AddAsync(account);
                    await _unitOfWork.SaveChangesAsync();
                    return Result.Success<Account, DomainError>(account);
                }
                else
                {
                    return Result.Failure<Account, DomainError>(DomainError.NotFound("Account with given number doesn't exist"));
                }
            }

        }

        public Task<Result<Account, DomainError>> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
