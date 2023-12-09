using _01_CustomEventsInPractice.Contracts;
using CustomEventsInPractice.Common;

namespace _01_CustomEventsInPractice.Models
{
    internal record Author : DomainEntity, IPublisher
    {
        private readonly List<ISubscriber>? subscribers;
        public Author(string name, string description)
        {
            Name = name;
            Description = description;
            subscribers = [];
        }
        public string Name { get; init; }
        public string Description { get; init; }

        public void AddSubscriber(ISubscriber subscriber)
        {
            subscribers?.Add(subscriber);
        }
        public void RemoveSubscriber(ISubscriber subscriber)
        {
            subscribers?.Remove(subscriber);
        }

        public void Publish(Article article)
        {
            Article createdArticle = article.Create();
            string subscriberUpdateMessage = createdArticle.ToString();
            Notify(subscriberUpdateMessage);
        }

        public void Update(Article article, string title, string description)
        {
            //actually it should call repository with article id to get the article
            Article updatedArticle = article.Update(title, description);
            string subscriberUpdateMessage = $"Article with {updatedArticle.Id} updated. New title = {title}, description = {description}";
            Notify(subscriberUpdateMessage);
        }

        private void Notify(string message)
        {
            subscribers?.ForEach(subscriber =>
            {
                subscriber.Update(message);
            });
        }

    }
}
