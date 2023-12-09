using _01_CustomEventsInPractice.Models;
using CustomEventsInPractice.Common;

namespace _01_CustomEventsInPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Author author = new("James", "Senior Developer");
            
            Article article = new("My simple article", "lorem ipsum",author.Id);

            User firstUser = new("Simon");
            User secondUser = new("Mike");

            firstUser.Subscribe(author);
            secondUser.Subscribe(author);
            //author.AddSubscriber(user);

            author.Publish(article);
            Console.WriteLine();
            Console.WriteLine("--------Changes in article-----------");
            article = article.WithTitle("Another title");
            author.RemoveSubscriber(secondUser);

            author.Publish(article);
        }
    }
}
