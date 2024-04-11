using DI.API.Models;

namespace DI.API.Repositories
{
    public interface ICardRepository
    {
        Task<Card?> GetCardByIdAsync(Guid cardId);
    }
}