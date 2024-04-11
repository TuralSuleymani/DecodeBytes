using DI.API.Repositories;
using CSharpFunctionalExtensions;
using DI.API.Models;
namespace DI.API.Services
{
    public class AccountService(IAccountRepository accountRepository, ICardService cardService) : IAccountService
    {
        private readonly IAccountRepository _accountRepository = accountRepository;
        private readonly ICardService _cardService = cardService;

        public async Task<Result<Account, string>> Bind(Guid accountId, Guid cardId)
        {
            var account = await _accountRepository.GetAccountByIdAsync(accountId);
            if (account is null)
            {
                return Result.Failure<Account, string>("No valid accountId provided");
            }
            else
            {
                var card = await _cardService.GetCardByIdAsync(cardId);
                if (card.IsFailure)
                    return Result.Failure<Account, string>(card.Error);
                else
                {
                    var newAccount = account.WithCardId(cardId);
                    return Result.Success<Account, string>(newAccount);
                }

            }
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAccountsAsync();
        }
    }
}
