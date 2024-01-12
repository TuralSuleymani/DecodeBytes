using _04_CustomEventsInPractice.RecommendedEvents.Contracts;

namespace _04_CustomEventsInPractice.RecommendedEvents.Contracts
{
    internal interface ISubscriber
    {
        void Subscribe(IPublisher publisher);
        void Unsubscribe(IPublisher publisher);
        void Update(string message);
    }
}
