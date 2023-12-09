using _04_CustomEventsInPractice.RecommendedEvents.Contracts;
using CustomEventsInPractice.Common;

namespace _03_CustomEventsInPractice.Events.Models
{
    internal record User : DomainEntity, ISubscriber
    {
        public string Name { get; init; }
        public User(string name)
        {
            Name = name;
        }
        public void Subscribe(IPublisher publisher)
        {
            publisher.OnUpdate += (obj, e) => Update(e.Message);
        }

        public void Unsubscribe(IPublisher publisher)
        {
            publisher.OnUpdate -= (obj, e) => Update(e.Message);
        }

        public void Update(string message)
        {
            Console.WriteLine($"User with Id = {Id} notified");
            Console.WriteLine(message);
        }
    }
}
