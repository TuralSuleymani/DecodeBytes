using ExtensionMethodsDemo.Common;
using ExtensionMethodsDemo.Services.Contracts;

namespace ExtensionMethodsDemo.Services.Extensions
{
    public static class AccountServiceExtensions
    {
        public static async Task<string> AsCsvAsync(this IAccountService accountService)
        {
            var allAccounts = await accountService.GetAllAccountsAsync();
            var properties = typeof(Account).GetProperties();
            var csv = string.Join(",", properties.Select(p => p.Name));
            csv += "\n";

            foreach (var item in allAccounts)
            {
                var values = properties.Select(p => p.GetValue(item).ToString());
                csv += string.Join(",", values);
                csv += "\n";
            }

            return csv;
        }

        public static async Task<IEnumerable<Account>> GetActiveAccountsAsync(this IAccountService accountService, Func<Account, bool> predicate)
        {
            var allAccounts = await accountService.GetAllAccountsAsync();
            List<Account> activeAccounts = new();
            foreach (var account in allAccounts)
            {
                if (predicate(account))
                {
                    activeAccounts.Add(account);
                }
            }
            return activeAccounts;
        }
    }
}
