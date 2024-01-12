using _02_CustomEventsInPractice.Delegates.Models;
using CustomEventsInPractice.Common;

namespace _02_CustomEventsInPractice.Delegates.Contracts
{
    internal interface IPublisher
    {
        void AddSubscriber(Guid subscriberId, SubscriberDelegate subscriber);
        void RemoveSubscriber(Guid subscriberId);
        void Publish(Article article);
    }
}
