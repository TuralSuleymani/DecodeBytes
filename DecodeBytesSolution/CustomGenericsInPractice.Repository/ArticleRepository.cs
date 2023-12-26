using CustomGenericsInPractice.Common;

namespace CustomGenericsInPractice.Repository
{
    public class ArticleRepository : IRepository<Article>
    {
        //GetAsync, Listasync

        private readonly List<Article> _articles;
        public ArticleRepository()
        {
            _articles = new List<Article>()
            {
              new Article("Simple title","Simple description",Guid.NewGuid())
            };
        }
        public Task<Article> GetAsync(Guid id)
        {
            return Task.FromResult(_articles.First(a => a.Id == id));
        }

        public Task<IEnumerable<Article>> ListAsync()
        {
            return Task.FromResult(_articles.AsEnumerable());
        }
    }
}
