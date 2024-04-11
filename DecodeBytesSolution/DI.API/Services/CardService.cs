using CSharpFunctionalExtensions;
using DI.API.Models;
using DI.API.Repositories;

namespace DI.API.Services
{
    public class CardService(ICardRepository cardRepository) : ICardService
    {
        private readonly ICardRepository _cardRepository = cardRepository;

        public async Task<Result<Card, string>> GetCardByIdAsync(Guid cardId)
        {
            var card = await _cardRepository.GetCardByIdAsync(cardId);
            if (card is null)
            {
                return Result.Failure<Card, string>("Not a valid card id");
            }
            return Result.Success<Card, string>(card);
        }
    }
}
