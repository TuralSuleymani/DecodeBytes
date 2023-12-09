using CustomEventsInPractice.Common;

namespace _04_CustomEventsInPractice.RecommendedEvents.Contracts
{
    public class PublishEventArgs(string message) : EventArgs
    {
        public string Message { get; init; } = message;
    }
    internal interface IPublisher
    {
        event EventHandler<PublishEventArgs> OnUpdate;
        void Publish(Article article);
    }
}
