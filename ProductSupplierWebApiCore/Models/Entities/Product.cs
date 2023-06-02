using ProductSupplierWebApiCore.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSupplierWebApiCore.Models.Entities
{
    public class Product:BaseEntitiy
    {
        public string ProductName { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }//tahmini teslim edilme zamanı
        public bool IsDelivered { get; set; }// teslim edildimi?
        public string Recevier { get; set; } // teslim alan kişi
       
        [Column ("money")]// decimal türünü sql için burada moneye çevirdim
        public decimal UnitPrice { get; set; }// toplam ücret 
        public int Quantity { get; set; }
        public Where Where { get; set; }
    }
}
