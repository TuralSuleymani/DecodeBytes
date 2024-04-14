
namespace DIDeepDive.API.Clients
{
    public class DefaultAccountNumberClient : IAccountNumberClient
    {
        public Guid GetAccountNumber()
        {
            return Guid.Parse("91f0b23c-6ec4-4c18-80f6-5343d026eb98");
        }
    }
}
