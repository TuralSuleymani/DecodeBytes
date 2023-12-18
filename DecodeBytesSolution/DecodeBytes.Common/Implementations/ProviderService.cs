using DecodeBytes.Common.Contracts;
using DecodeBytes.Provider;
using System.Reflection;

namespace DecodeBytes.Common.Implementations
{
    public class ProviderService : IProviderService
    {
        private const string FolderPath = "libs";
        private const string Extension = "*.dll";
        private List<IBankProvider> _providers = [];
        private readonly string _libsPath;
        public ProviderService()
        {
            _libsPath = ApplicationPath.PathTo(FolderPath);
        }
        public IEnumerable<IBankProvider> GetProviders()
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
                IEnumerable<Type> providerTypes = assemblyTypes.Where(t => t.GetInterface(nameof(IBankProvider), true) != null);

                // Create instances of found providers
                foreach (Type providerType in providerTypes)
                {
                    yield return (IBankProvider)Activator.CreateInstance(providerType);
                }
            }
        }

    }
}
