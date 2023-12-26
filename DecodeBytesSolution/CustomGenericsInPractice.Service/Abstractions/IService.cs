using CSharpFunctionalExtensions;


namespace CustomGenericsInPractice.Service.Abstractions
{
    public interface IService<T>
    {
        Task<IResult<T, string>> AddAsync(T model);
        Task<IResult<T, string>> GetAsync(Guid id);

    }
}
