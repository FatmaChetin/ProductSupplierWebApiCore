using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductSupplierWebApiCore.Models.Context;
using ProductSupplierWebApiCore.Models.Entities;
using ProductSupplierWebApiCore.RequestModel;

namespace ProductSupplierWebApiCore.Controllers
{
    [ApiController]// apiye ait bir controller o yüzden attribute nu verdim
    [Route("api/[controller]")]//apinin route belirten attribute
    public class ProductSupplierController:ControllerBase
    {
        MyContext _db;
        public ProductSupplierController(MyContext db)
        {
            _db = db;
        }
        private static List<Product> products = new List<Product> 
        { 
                new Product
                {
                    ID=1,
                    ProductName="tadelle",
                    IsDelivered=true,
                    UnitPrice=25,
                    Quantity=5,
                    EstimatedDeliveryDate=DateTime.Today
                },
                new Product
                {
                    ID=2,
                    ProductName="halley",
                    IsDelivered=false,
                    UnitPrice=10,
                    Quantity=8,
                    EstimatedDeliveryDate=DateTime.Today
                },
                new Product
                {
                    ID=3,
                    ProductName="schweppes",
                    IsDelivered=false,
                    UnitPrice=8,
                    Quantity=10,
                    EstimatedDeliveryDate=DateTime.Now,
                  
                } };
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAllProduct()
        {
            return Ok(products);
        }
        [HttpGet]
        [Route("{id }")]// bu şekilde route vermezsek swagger çalışmıyor route bulamadığı için. ister böyle istersekte [HttpGet("{id}")] şeklinde verebiliriz 
        public async Task<ActionResult<List<Product>>> GetProduct(int id)
        {
            Product product=products.Find(x => x.ID==id); 
            return Ok(product);
        }
        [HttpPost]
        public async Task<ActionResult<Product>> DeliveryProducts(ProductSupplierRequestModel item)
        {
            Product pr = _db.Products.FirstOrDefault(x=> x.ProductName== item.ProductName && x.UnitPrice==item.UnitPrice );
            if (pr!=null) 
            {
                if (pr.EstimatedDeliveryDate>item.EstimatedDeliveryDate)
                {
                    return BadRequest("İstenilen Ürün O tarihte teslim edilemez");
                }
                else if (pr.EstimatedDeliveryDate<item.EstimatedDeliveryDate)
                {
                    return Ok("istenilen ürünler o tarihte teslim edilebilir.");
                }
                // buradaki karar mekanizmasında istenilen tarihte teslim edilip edelemeyeceğine göre cevabı.
                TotalPrice(item,pr);
            }
            return BadRequest("istediğiniz ürün bilgileri yanlış lütfen ürün bilgilerinizi kontrol ediniz.");
        }
        private void TotalPrice( ProductSupplierRequestModel item, Product pr)
        {
            item.TotalPrice += ((pr.UnitPrice)*(pr.Quantity));
        }
    }
}
