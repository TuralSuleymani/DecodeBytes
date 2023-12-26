using CustomGenericsInPractice.Common;

namespace CustomGenericsInPractice.Repository
{
    internal interface IRepository<T> where T:DomainEntity
    {
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> ListAsync();
    }
}
