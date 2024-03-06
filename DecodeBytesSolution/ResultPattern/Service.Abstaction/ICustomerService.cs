using CSharpFunctionalExtensions;
using Domain.Models;

namespace Service.Abstaction
{
    public interface ICustomerService
    {
        Task<bool> IsExistsAsync(Guid customerId);
    }
}
