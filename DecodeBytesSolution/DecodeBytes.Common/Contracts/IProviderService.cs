using DecodeBytes.Common.Implementations;

namespace DecodeBytes.Common.Contracts
{
    public interface IProviderService
    {
        IEnumerable<BankProvider> GetProviders();
    }
}