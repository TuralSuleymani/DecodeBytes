using _03_CustomEventsInPractice.Events.Models;
using CustomEventsInPractice.Common;

namespace _03_CustomEventsInPractice.Events.Contracts
{
    internal interface IPublisher
    {
        event SubscriberDelegate? OnUpdate;
        void Publish(Article article);
    }
}
