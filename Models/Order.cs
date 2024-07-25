using System.ComponentModel.DataAnnotations;

namespace FutureFridgesCW.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public string? SupplierName { get; set; }
        public string ProductName { get; set; }
        public double quantity { get; set; }
    }
}
