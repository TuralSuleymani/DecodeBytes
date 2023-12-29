namespace DecodeBytes.Entity
{
    public class Customer(int id, string name)
    {
        public int Id { get; init; } = id;
        public string Name { get; init; } = name;
    }
}
