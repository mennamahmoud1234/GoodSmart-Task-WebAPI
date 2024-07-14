
using GoodSmart_Task.Data;
using GoodSmart_Task.Data.Models;
using GoodSmart_Task.HelpersMethod;
using Microsoft.EntityFrameworkCore;

namespace GoodSmart_Task
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AppDbContext>(op => op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<ProductMethods>();
           builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDev",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200") // Angular development server URL
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAngularDev");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
