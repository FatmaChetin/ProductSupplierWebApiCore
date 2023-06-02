using ProductSupplierWebApiCore.Models.Enums;

namespace ProductSupplierWebApiCore.Models.Entities
{
    public abstract class BaseEntitiy
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public DataStatus DataStatus { get; set; }
        public BaseEntitiy()
        {
            CreatedDate=DateTime.Now;
            DataStatus = DataStatus.Inserted;
        }

    }
}
