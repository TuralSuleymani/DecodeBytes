using System.ComponentModel.DataAnnotations.Schema;

namespace EFCOreWithSP.Database
{
    [Table("OrderDetails",Schema ="Shopping")]
    internal class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public override string ToString()
        {
            return $"OrderDetailId: {OrderDetailId}, OrderId: {OrderId}, Name: {Name}, Color: {Color}, Size: {Size}";
        }
    }
}
