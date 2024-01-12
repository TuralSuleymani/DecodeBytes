using _03_CustomEventsInPractice.Events.Contracts;
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
            publisher.OnUpdate += Update;
        }

        public void Unsubscribe(IPublisher publisher)
        {
            publisher.OnUpdate -= Update;
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
