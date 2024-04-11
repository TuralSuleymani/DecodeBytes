using DI.API.Models;

namespace DI.API.Repositories
{
    public class CardRepository : ICardRepository
    {
        private static List<Card> _card;
        public CardRepository()
        {
            _card = new List<Card>()
            {
                new Card(Guid.NewGuid(),"Card1"),
                new Card(Guid.Parse("59ca57e8-62f3-4da5-bc3d-1dd36907c283"),"card2"),
            };
        }
        public Task<Card?> GetCardByIdAsync(Guid cardId)
        {
            return Task.FromResult(_card.Find(x => x.id == cardId));
        }
    }
}
