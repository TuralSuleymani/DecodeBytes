namespace ExtensionMethodsDemo.Services.Contracts
{
    public interface ICreditCardService
    {
        Task<string?> GetCardNumberByAccountIdAsync(Guid accountId);
    }
}
