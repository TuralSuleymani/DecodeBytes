using DecodeBytes.Provider;

namespace EdenZeroBankProvider
{
    [BankProvider("Eden Zero")]
    public class EdenZeroProvider
    {
        //it should encapsulate the service call, but for simplicity,we're using in-memory data structure
        private readonly Dictionary<string, decimal> Cards;
        public EdenZeroProvider()
        {
           Cards = LoadCards();
        }

        [BankOperation(BankOperationType.AddToBalance)]
        public void AddToBalance(CardNumber cardNumber, decimal amount)
        {
            if (!IsCardNumberExist(cardNumber.Number))
                throw new ArgumentException("Card number is not valid");
            Cards[cardNumber.Number] += amount;
        }
        private bool IsCardNumberExist(string cardNumber)
        {
           return Cards.Where(x => x.Key == cardNumber).Any();
        }
        private static Dictionary<string, decimal> LoadCards()
        {
            return new Dictionary<string, decimal>
            {
                { "1111-2222-3333-4444", 500 },
                { "1111-2222-3333-5555", 700 }
            };
        }

        [BankOperation(BankOperationType.GetBalance)]
        public decimal GetBalance(CardNumber cardNumber)
        {
            if (!IsCardNumberExist(cardNumber.Number))
                throw new ArgumentException("Card number is not valid");
            return Cards[cardNumber.Number];
        }
    }
}
