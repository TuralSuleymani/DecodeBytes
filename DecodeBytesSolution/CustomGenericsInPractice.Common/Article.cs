namespace CustomGenericsInPractice.Common
{
    public record Article : DomainEntity
    {
        public Article()
        {
            
        }
        public Article(string title, string description, Guid authorId)
        {
            Title = title;
            Description = description;
            AuthorId = authorId;
        }
        public string Title { get; init; }
        public string Description { get; init; }
        public Guid AuthorId { get; init; }

        public bool IsDeleted { get; init; } = false;
        public bool IsPublished { get; init; } = false;

        public Article Create()
        {
            return this with { IsPublished = true };
        }

        public Article Update(string title, string description)
        {
            return this with { Title = title, Description = description };
        }

        public Article Draft()
        {
            return this with { IsPublished = false };
        }

        public Article Delete()
        {
            return this with { IsDeleted = false };
        }
        public Article WithTitle(string title)
        {
            return this with { Title = title };
        }

        public Article WithDescription(string description)
        {
            return this with { Description = description };
        }

    }
}
