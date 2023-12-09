using _03_CustomEventsInPractice.Events.Models;
using _04_CustomEventsInPractice.RecommendedEvents.Contracts;
using _04_CustomEventsInPractice.RecommendedEvents.Models;
using CustomEventsInPractice.Common;

namespace _03_CustomEventsInPractice.Events
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Author author = new("James", "Senior Developer");

            Article article = new("My simple article", "lorem ipsum", author.Id);

            User firstUser = new("Simon");
            User secondUser = new("Mike");

            //firstUser.Subscribe(author);
            //secondUser.Subscribe(author);

            //or

            EventHandler<PublishEventArgs> firstUserHandler
                = new((obj, pArgs) => firstUser.Update(pArgs.Message));

            author.OnUpdate += firstUserHandler;
            author.OnUpdate += (obj, e) => secondUser.Update(e.Message);

            Console.WriteLine("--------First publication-----------");
            author.Publish(article);

            Console.WriteLine();
            Console.WriteLine("--------Changes in article-----------");

            article = article.WithTitle("Another title");
            author.OnUpdate -= firstUserHandler;
            author.Publish(article);
        }
    }
}
