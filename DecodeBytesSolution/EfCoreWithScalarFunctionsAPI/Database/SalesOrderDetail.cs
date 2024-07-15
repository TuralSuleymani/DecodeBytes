using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreWithScalarFunctionsAPI.Database
{
    [Table("SalesOrderDetail", Schema = "Sales")]
    public class SalesOrderDetail
    {
        public int SalesOrderDetailId { get; set; }
        public int SalesOrderId { get; set; }
        public int? ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
        public int SpecialOfferId { get; set; }
    }
}
