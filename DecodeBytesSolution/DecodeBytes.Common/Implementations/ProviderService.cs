using DecodeBytes.Common.Contracts;
using DecodeBytes.Common.Extensions;
using DecodeBytes.Provider;
using System.Reflection;

namespace DecodeBytes.Common.Implementations
{
    public class ProviderService : IProviderService
    {
        private const string FolderPath = "libs";
        private const string Extension = "*.dll";
        private List<BankProvider> _providers = [];
        private readonly string _libsPath;
        public ProviderService()
        {
            _libsPath = ApplicationPath.PathTo(FolderPath);
        }
        public IEnumerable<BankProvider> GetProviders()
        {
            _providers = [];
            string[] providers = Directory.GetFiles(_libsPath, Extension);

            //for simplicity excaped LINQ query...
            //for every provider ....
            foreach (string provider in providers)
            {
                //load it into application..
                Assembly assembly = Assembly.LoadFile(provider);

                //get all types in assembly
                Type[] assemblyTypes = assembly.GetTypes();


                // Filter types implementing IBankProvider
                IEnumerable<Type> providerTypes = assemblyTypes.Where(t => t.GetCustomAttribute<BankProviderAttribute>() is not null);

                // Create instances of found providers
                foreach (Type providerType in providerTypes)
                {
                    var instance = Activator.CreateInstance(providerType);

                    var getBalance = providerType.GetMethod(BankOperationType.GetBalance);

                    var addToBalance = providerType.GetMethod(BankOperationType.AddToBalance);

                    // Use the correct delegate type based on the method's signature
                    var addToBalanceDelegate = (Action<CardNumber, decimal>)Delegate.CreateDelegate(
                        typeof(Action<CardNumber, decimal>), instance, addToBalance!);

                    var getBalanceDelegate = (Func<CardNumber, decimal>)Delegate.CreateDelegate(
                        typeof(Func<CardNumber, decimal>), instance, getBalance!);

                    yield return new BankProvider
                    {
                        ProviderName = providerType.GetCustomAttribute<BankProviderAttribute>()?.ProviderName ?? "Unknown",
                        AddToBalance = addToBalanceDelegate,
                        GetBalance = getBalanceDelegate
                    };
                }
            }
        }

    }
}
