
using Microsoft.EntityFrameworkCore;
using ProductSupplierWebApiCore.Models.Context;

namespace ProductSupplierWebApiCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            // sql ile baðlantýsýný yapabilmesi için gereken builder iþlemlerini burada yaptým.
            builder.Services.AddDbContextPool<MyContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}