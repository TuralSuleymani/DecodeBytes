using _01_CustomEventsInPractice.Models;
using _03_CustomEventsInPractice.Events.Models;
using CustomEventsInPractice.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            author.OnUpdate += firstUser.Update;
            author.OnUpdate += secondUser.Update;

            Console.WriteLine("--------First publication-----------");
            author.Publish(article);
            
            Console.WriteLine();
            Console.WriteLine("--------Changes in article-----------");

            article = article.WithTitle("Another title");
            author.OnUpdate -= secondUser.Update;
            author.Publish(article);
        }
    }
}
