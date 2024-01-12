namespace _01_CustomEventsInPractice.Contracts
{
    internal interface ISubscriber
    {
        void Subscribe(IPublisher publisher);
        void Unsubscribe(IPublisher publisher);
        void Update(string message);
    }
}
