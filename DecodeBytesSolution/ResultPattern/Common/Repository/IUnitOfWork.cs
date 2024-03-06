namespace Common.Repository
{
    public interface IUnitOfWork
    {
        Task AddAsync<T>(T model) where T : IDomainModel;

        Task SaveChangesAsync();
    }
}
