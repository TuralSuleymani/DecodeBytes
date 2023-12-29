using DecodeBytes.Entity;

namespace DecodeBytes.Repository
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetCustomerByIdAsync(int id);
    }
}