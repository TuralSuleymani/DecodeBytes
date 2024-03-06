using Domain.Models.ValueTypes;

namespace Domain.Models
{
    /// <summary>
    /// Bad sign. Dont do it for real domain models
    /// </summary>
    public class AnemicAccount
    {
        public Guid AccountId { get; set; }
        public Guid CustomerId { get; set; }
        public required string AccountNumber { get; set; }

        public AccountType AccountType { get; set; }

        public required string AccountName { get; set; }
    }
}
