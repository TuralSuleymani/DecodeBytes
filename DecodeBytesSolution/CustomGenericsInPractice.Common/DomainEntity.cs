namespace CustomGenericsInPractice.Common
{
    public abstract record DomainEntity
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public DateTime Created { get; init; } = DateTime.Now;
        public DateTime Updated { get; init; } = DateTime.Now;
    }
}
