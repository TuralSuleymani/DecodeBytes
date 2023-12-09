using _04_CustomEventsInPractice.RecommendedEvents.Contracts;
using CustomEventsInPractice.Common;

namespace _04_CustomEventsInPractice.RecommendedEvents.Models
{
    internal record Author : DomainEntity, IPublisher
    {
        public event EventHandler<PublishEventArgs>? OnUpdate;
        public Author(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; init; }
        public string Description { get; init; }

        public void Publish(Article article)
        {
            Article createdArticle = article.Create();
            string subscriberUpdateMessage = createdArticle.ToString();
            OnUpdate?.Invoke(this, new PublishEventArgs(subscriberUpdateMessage));
        }

        public void Update(Article article, string title, string description)
        {
            //actually it should call repository with article id to get the article
            Article updatedArticle = article.Update(title, description);
            string subscriberUpdateMessage = $"Article with {updatedArticle.Id} updated. New title = {title}, description = {description}";
            OnUpdate?.Invoke(this, new PublishEventArgs(subscriberUpdateMessage));
        }

    }
}
