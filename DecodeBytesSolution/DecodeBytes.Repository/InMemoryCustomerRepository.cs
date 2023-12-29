using DecodeBytes.Entity;

namespace DecodeBytes.Repository
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customerList;
        public InMemoryCustomerRepository()
        {
            _customerList = [new Customer(1, "Simon"), new Customer(2, "Joseph")];
        }
        public async Task<Customer?> GetCustomerByIdAsync(int id)
        {
            await Task.Delay(TimeSpan.FromMilliseconds(6));
            return await Task.FromResult(_customerList.FirstOrDefault(x => x.Id == id));
        }

    }
}
