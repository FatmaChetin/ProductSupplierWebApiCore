

namespace ProductSupplierWebApiCore.ResponseModel
{
    public class ProductSupplierResponseModel
    {
        public string ProductName { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public bool IsDelivered { get; set; }
        public string Recevier { get; set; }
        public int Quantity { get; set; }
        public string Where { get; set; }
    }
}
