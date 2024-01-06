namespace DecodeBytes.Provider
{
    /// <summary>
    /// Contract for implementing late-binded providers
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
   public sealed class BankProviderAttribute(string providerName) : Attribute
    {
        public string ProviderName
        {
            get { return providerName; }
        }
    }

    public enum BankOperationType
    {
        AddToBalance,
        GetBalance
    }

    /// <summary>
    /// Contract for implementing late-binded providers for methods
    /// </summary>
    [System.AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class BankOperationAttribute(BankOperationType bankOperationType) :Attribute
    {
        public BankOperationType BankOperationType
        {
            get { return bankOperationType; }
        }
    }

}
