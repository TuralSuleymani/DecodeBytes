namespace DIDeepDive.API.Clients
{
    public class AccountNumberClient : IAccountNumberClient
    {
        private Guid generatedId;
        public AccountNumberClient()
        {
            generatedId = Guid.NewGuid();
        }
        public Guid GetAccountNumber()
        {
            return generatedId;
        }
    }
}
