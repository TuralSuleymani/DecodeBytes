using _02_CustomEventsInPractice.Delegates.Models;
using _02_CustomEventsInPractice.Delegates.Contracts;
using CustomEventsInPractice.Common;

namespace _02_CustomEventsInPractice.Delegates.Models
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
            publisher.AddSubscriber(Id, this.Update);
        }

        public void Unsubscribe(IPublisher publisher)
        {
            publisher.RemoveSubscriber(Id);
        }

        public void Update(string message)
        {
            Console.WriteLine(message);
        }
    }
}
