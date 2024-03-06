using Service.Abstaction;

namespace Service.External
{
    public class CustomerService : ICustomerService
    {
        public Task<bool> IsExistsAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
