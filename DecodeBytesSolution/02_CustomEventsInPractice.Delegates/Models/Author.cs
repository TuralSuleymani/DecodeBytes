using _02_CustomEventsInPractice.Delegates.Models;
using _02_CustomEventsInPractice.Delegates.Contracts;
using CustomEventsInPractice.Common;

namespace _02_CustomEventsInPractice.Delegates.Models
{
    internal record Author : DomainEntity, IPublisher
    {
        private readonly Dictionary<Guid,SubscriberDelegate>? subscribers;
        public Author(string name, string description)
        {
            Name = name;
            Description = description;
            subscribers = [];
        }
        public string Name { get; init; }
        public string Description { get; init; }

        //loosing identifier over subscriber if it is a delegate..
        public void AddSubscriber(Guid subscriberId, SubscriberDelegate subscriber)
        {
            subscribers?.Add(subscriberId, subscriber);
        }
        public void RemoveSubscriber(Guid subscriberId)
        {
            subscribers?.Remove(subscriberId);
        }

        public void Publish(Article article)
        {
            Article createdArticle = article.Create();
            Notify(createdArticle.ToString());
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
            foreach (var item in subscribers?.Values)
            {
                item(message);
            }
        }

    }
}
