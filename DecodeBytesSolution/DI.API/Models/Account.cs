namespace DI.API.Models
{
    public record Account(Guid AccountId, string AccountName, Guid CardId)
    {
        public Account WithCardId(Guid cardId)
        {
            return this with { CardId = cardId };
        }
    }
}
