namespace ExtensionMethodsDemo.Common
{
    public record Account
    {
        public Guid AccountId { get; init; }
        public string AccountNumber { get; init; }
        public bool IsDisabled { get; init; }
        public Guid? RootAccountId { get; init; }
        public Account
            (string accountNumber
            , bool isDisabled
            , Guid? rootAccountId)
        {
            AccountId = Guid.NewGuid();
            AccountNumber = accountNumber;
            IsDisabled = isDisabled;
            RootAccountId = rootAccountId;
        }

        public Account ChangeAccountNumber(string accountNumber)
        {
            return this with
            {
                AccountNumber = accountNumber
            };
        }

        public Account Enable()
        {
            return !IsDisabled ? this : this with { IsDisabled = true };
        }

    }
}
