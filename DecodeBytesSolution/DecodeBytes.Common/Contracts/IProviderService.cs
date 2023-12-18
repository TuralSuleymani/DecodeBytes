using DecodeBytes.Provider;

namespace DecodeBytes.Common.Contracts
{
    public interface IProviderService
    {
        IEnumerable<IBankProvider> GetProviders();
    }
}