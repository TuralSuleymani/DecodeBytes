namespace _02_CustomEventsInPractice.Delegates.Contracts
{
    internal interface ISubscriber
    {
        void Subscribe(IPublisher publisher);
        void Unsubscribe(IPublisher publisher);
        void Update(string message);
    }
}
