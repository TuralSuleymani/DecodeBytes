namespace DecodeBytes.Provider
{
    /// <summary>
    /// Contract for implementing late-binded providers
    /// </summary>
    public interface IBankProvider
    {
        string ProviderName { get; }
        void AddToBalance(CardNumber cardNumber, decimal amount);
        decimal GetBalance(CardNumber cardNumber);
    }
}
