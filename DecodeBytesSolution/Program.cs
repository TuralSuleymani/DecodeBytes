using CsharpDelegates.Database.Models;

namespace CsharpDelegates
{
    internal class Program
    {
        static void Main()
        {
            var cards = GetCards(x => x.HolderName == "Hanma Baki");
            foreach (var card in cards)
            {
                Console.WriteLine(card);
            }
            Console.ReadLine();
        }

        private static List<Card> GetCardsByCustomerIdEqualto4()
        {
            List<Card> cards = [];
            using var dbcontext = new CustomerAppDbContext();
				var dbCards = dbcontext.Cards.ToList();//materialize
            foreach (var card in dbCards)
            {
                if(card.CustomerId == 4)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }

        private static List<Card> GetCardsByCustomerId(int customerId)
        {
            List<Card> cards = [];
            using var dbcontext = new CustomerAppDbContext();
            var dbCards = dbcontext.Cards.ToList();//materialize
            foreach (var card in dbCards)
            {
                if (card.CustomerId == customerId)
                {
                    cards.Add(card);
                }
            }
            return cards;
        }

        private static List<Card> GetCardsByCustomerDelegate(CustomerDelegate customerDelegate)
        {
            List<Card> cards = [];
            using var dbcontext = new CustomerAppDbContext();
            var dbCards = dbcontext.Cards.ToList();//materialize
            foreach (var card in dbCards)
            {
                if (customerDelegate(card.CustomerId))
                {
                    cards.Add(card);
                }
            }
            return cards;
        }

        private static List<Card> GetCards(Predicate<Card> predicate)
        {
            List<Card> cards = [];
            using var dbcontext = new CustomerAppDbContext();
            var dbCards = dbcontext.Cards.ToList();//materialize
            foreach (var card in dbCards)
            {
                if (predicate(card))
                {
                    cards.Add(card);
                }
            }
            return cards;
        }
    }
    //Func, Action,Predicate
    public delegate bool CustomerDelegate(int customerId);
   // public delegate bool CustomerCardDelegate(Card card);
}
