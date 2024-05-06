using ExpApp.Common.Extensions;
namespace ExpApp.Domain
{
    public record Account
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string AccountNumber { get; init; }
        public Account(string name, string accountNumber)
        {
            Id = Guid.NewGuid();
            Name = name.IsNotNullOrEmpty();
            AccountNumber = accountNumber.IsInValidRange(4,10);
        }
    }
}
