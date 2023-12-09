using System.Net;

namespace CsharpDelegates.Database.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string HolderName { get; set; }
        public string ExpiryDate { get; set; }
        public string Number { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, HolderName = {HolderName}, Number = {Number},ExpiryDate = {ExpiryDate}, CustomerId = {CustomerId}";
        }
    }
}
