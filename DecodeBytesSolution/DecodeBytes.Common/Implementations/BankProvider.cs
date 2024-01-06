using DecodeBytes.Provider;

namespace DecodeBytes.Common.Implementations
{
    public class BankProvider
    {
        public required string ProviderName { get; init; }
        public required Action<CardNumber,decimal> AddToBalance { get; init; }
        public required Func<CardNumber, decimal> GetBalance { get; init; }
    }
}
