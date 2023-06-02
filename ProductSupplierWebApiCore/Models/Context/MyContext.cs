using Microsoft.EntityFrameworkCore;
using ProductSupplierWebApiCore.Models.Entities;

namespace ProductSupplierWebApiCore.Models.Context
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options) 
        {

        }
        public DbSet<Product> Products { get; set; }
    }
}
