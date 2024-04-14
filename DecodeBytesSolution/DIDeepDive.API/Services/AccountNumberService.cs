using DIDeepDive.API.Clients;

namespace DIDeepDive.API.Services
{
    public class AccountNumberService([FromKeyedServices("ac1")]IAccountNumberClient accountNumberClient)
    {
        private readonly IAccountNumberClient _accountNumberClient = accountNumberClient;

        public Guid GetAccountNumber()
        {
            return _accountNumberClient.GetAccountNumber();
        }
    }
}
