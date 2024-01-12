namespace _03_CustomEventsInPractice.Events.Contracts
{
    internal interface ISubscriber
    {
        void Subscribe(IPublisher publisher);
        void Unsubscribe(IPublisher publisher);
        void Update(string message);
    }
}
