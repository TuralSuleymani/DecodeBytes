using DecodeBytes.Repository;

namespace DecodeBytes.Service
{
    public class CustomerService(ICustomerRepository customerRepository)
    {
        //only for testing purpose
        public static CustomerService Create()
        {
            return new CustomerService(new InMemoryCustomerRepository());
        }
        private readonly ICustomerRepository _customerRepository = customerRepository;
        public async Task<bool> IsCustomerExistAsync(int id)
        {
            //apply some business logic
            var customerResponse = await _customerRepository.GetCustomerByIdAsync(id);
            if (customerResponse is null)
                return false;
            return true;
        }
    }
}
