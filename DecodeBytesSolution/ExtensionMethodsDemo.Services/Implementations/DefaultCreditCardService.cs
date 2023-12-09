using ExtensionMethodsDemo.Services.Contracts;

namespace ExtensionMethodsDemo.Services.Implementations
{
    public class DefaultCreditCardService : ICreditCardService
    {
        public Task<string?> GetCardNumberByAccountIdAsync(Guid accountId)
        {
            return Task.FromResult("4564533")!;
        }
    }
}
