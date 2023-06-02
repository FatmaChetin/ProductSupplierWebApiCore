using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupplierWebApiCore.RequestModel
{
    public class ProductSupplierRequestModel
    {
        public string ProductName { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public string Recevier { get; set; } 
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string Where { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
