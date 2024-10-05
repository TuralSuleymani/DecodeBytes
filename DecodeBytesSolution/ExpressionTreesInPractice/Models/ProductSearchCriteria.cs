namespace ExpressionTreesInPractice.Models
{
    public record PriceRange(decimal? Min, decimal? Max);
    public record Category(string Name);
    public record ProductName(string Name);
    public class ProductSearchCriteria
    {
        public bool? IsActive { get; set; }
        public PriceRange? Price { get; set; }
        public Category[]? Categories { get; set; }
        public ProductName[]? Names { get; set; }
    }
}
