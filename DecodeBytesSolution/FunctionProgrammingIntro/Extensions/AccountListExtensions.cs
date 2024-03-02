namespace FunctionProgrammingIntro.Extensions
{
    public static class AccountListExtensions
    {
        public static IEnumerable<Account> ByCity(this IEnumerable<Account> accounts, string city)
        {
            return accounts.Where(x => x.City == city);
        }
    }
}
