using Application.Implementations;
using Application.Interface;
using Infrastructure.ProductProvider;
using MongoDB.Driver;

namespace product_service
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddApiVersioning();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductProvider, ProductProvider>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var connectionString = builder.Configuration.GetSection("MONGODBURI").Value;
            builder.Services.AddSingleton(new MongoClient(connectionString));
            
            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}