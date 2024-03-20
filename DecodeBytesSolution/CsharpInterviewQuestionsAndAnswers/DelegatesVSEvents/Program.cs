namespace DelegatesVSEvents
{

    internal class Program
    {
        static void Main(string[] args)
        {
            #region delegates
            Accounts accounts = new();
            var accountEventHandlerResponse = accounts.GetAccountBy(new AccountEventHandler(x => x.Number == "1111111"));
            accounts.GetAccountBy(new AccountEventHandler(x => x.Name == "dsfdsfdsf"));
            var funcEventHandlerResponse = accounts.GetAccountBy(new Func<Account, bool>(x => x.Name.Contains("Mr.Accou")));
            #endregion

            #region Event register
            //create account
            Account account = new("Mr.Account", "456546ADF");

            //register to the event
            account.AccountChanged += Account_AccountChanged;

            //trig the operation
            account.ChangeNumber("11112222");
            #endregion

            #region Register more..and unregister
            account.AccountChanged += Account_AccountChanged2;
            account.AccountChanged -= Account_AccountChanged;
            account.ChangeNumber("44444555");
            #endregion

            Console.ReadLine();
        }

        #region Event operations
        private static void Account_AccountChanged(Guid accountId, string oldValue, string newValue)
        {
            Console.WriteLine($"Account changed from {oldValue} to {newValue} for the account {accountId}");
        }
        private static void Account_AccountChanged2(Guid accountId, string oldValue, string newValue)
        {
            Console.WriteLine($"Account changed 2 from {oldValue} to {newValue} for the account {accountId}");
        }
        #endregion
    }
}
