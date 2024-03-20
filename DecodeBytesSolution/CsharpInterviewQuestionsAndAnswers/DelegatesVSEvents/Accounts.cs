namespace DelegatesVSEvents
{
    //outside of the class
    public delegate bool AccountEventHandler(Account account);

    internal class Accounts
    {
        private readonly List<Account> _accounts;
        public Accounts()
        {
            _accounts =
            [
                new("Mr.Account 1", "123456"),
                new("Mr.Account 2", "111111"),
                new("Mr.Account 3", "222222"),
                new("Mr.Account 4", "333333"),
            ];
        }

        public Account? GetExactAccountName()
        {
            return _accounts.FirstOrDefault(a => a.Name == "Mr.Account 1");
        }

        public Account? GetByName(string accountName)
        {
            return _accounts.FirstOrDefault(a => a.Name == accountName);
        }

        public Account? GetByNumber(string accountNumber)
        {
            return _accounts.FirstOrDefault(a => a.Number == accountNumber);
        }

        public List<Account> GetAccountBy(AccountEventHandler accountEventHandler)
        {
            List<Account> accounts = [];
            foreach (var account in _accounts)
            {
                if(accountEventHandler(account))
                {
                    accounts.Add(account);
                }
            }
            return accounts;
        }

        public List<Account> GetAccountBy(Func<Account, bool> account)
        {
            return _accounts.Where(account).ToList();
        }
    }
}
