using _01_CustomEventsInPractice.Models;
using CustomEventsInPractice.Common;

namespace _01_CustomEventsInPractice.Contracts
{
    internal interface IPublisher
    {
        void AddSubscriber(ISubscriber subscriber);
        void RemoveSubscriber(ISubscriber subscriber);
        void Publish(Article article);
    }
}
