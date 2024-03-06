using Common;
using Domain.Models.Extensions;
using Domain.Models.ValueTypes;

namespace Domain.Models
{
    public record Account: IDomainModel
    {
        //better to use strongly-typed Ids
        public Guid AccountId { get; init; }
        public Guid CustomerId { get; init; }
        public string AccountNumber { get; init; }

        public AccountType AccountType { get; init; }

        public string AccountName { get; init; }
        public Account(Guid accountId, Guid customerId, string accountNumber, AccountType accountType, string accountName)
        {
            accountNumber.IsNotNull();
            accountName.IsNotBlank();
            AccountId = accountId;
            CustomerId = customerId;
            AccountNumber = accountNumber;
            AccountType = accountType;
            AccountName = accountName;
        }
        public Account WithAccountNumber(string accountNumber) =>
                this with { AccountNumber = accountNumber };
    }
}
