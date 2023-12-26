using CustomGenericsInPractice.Common;

namespace CustomGenericsInPractice.Repository
{
    internal class AuthorRepository : IRepository<Author>
    {
        private readonly List<Author> _authors;
        public AuthorRepository()
        {
            _authors = new List<Author>()
            {
              new Author("Simple title","Simple description")
            };
        }
        public Task<Author> GetAsync(Guid id)
        {
            return Task.FromResult(_authors.First(a => a.Id == id));
        }

        public Task<IEnumerable<Author>> ListAsync()
        {
            return Task.FromResult(_authors.AsEnumerable());
        }
    }
}
