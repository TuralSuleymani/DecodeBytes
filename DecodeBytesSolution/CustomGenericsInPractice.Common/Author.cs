namespace CustomGenericsInPractice.Common
{
    public record Author : DomainEntity
    {
        public Author()
        {
            
        }
        public Author(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public string Name { get; init; }
        public string Description { get; init; }
    }
}
