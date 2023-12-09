using CsharpDelegates.Database.Models;

namespace CsharpDelegates
{
    internal class Program
    {
        static void Main()
        {
            //var cards = GetCardsByCustomerId(3);
            var cards = GetCards(x=>x.HolderName== "Hanma Baki");
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
            foreach (var card in dbcontext.Cards)
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
            foreach (var card in dbcontext.Cards)
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
            foreach (var card in dbcontext.Cards)
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
            foreach (var card in dbcontext.Cards)
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
