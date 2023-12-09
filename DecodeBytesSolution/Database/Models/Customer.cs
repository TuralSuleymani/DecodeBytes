namespace CsharpDelegates.Database.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Card> Cards { get; set; }
        public override string ToString()
        {
            return $"Id = {Id}, Name = {Name}, Address = {Address}";
        }
    }
}
