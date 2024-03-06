using Common.Repository;
using Domain.Models;
using Repository.Abstraction;
using Service.Abstaction;

namespace Service.Core
{
    public class AccountService(
              ICustomerService customerService
            , IAccountRepository accountRepository
            , IUnitOfWork unitOfWork) : IAccountService
    {
        private readonly ICustomerService _customerService = customerService;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly IAccountRepository _accountRepository = accountRepository;

        public async Task<Account> AddAsync(Account account)
        {
            bool isCustomerExist = await _customerService.IsExistsAsync(account.CustomerId);
            if (!isCustomerExist)
            {
                throw new Exception("Customer with given Id doesn't exist");
            }
            else
            {
                bool isAccountExist = await _accountRepository.IsExistsAsync(account.AccountNumber);
                if (isAccountExist)
                {
                    await _unitOfWork.AddAsync(account);
                    await _unitOfWork.SaveChangesAsync();
                    return account;
                }
                else
                {
                    throw new Exception("Account with given number doesn't exist");
                }
            }

        }

        public Task<Account?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
