
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PrimeiraApi.Repositories.Interfaces;
using PrimeiraApi.Repositories;
using PrimeiraApi.Data;

namespace TraineeSenai
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
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Trainee Senai",
                    Version = "v1"
                });
            });


            builder.Services
                .AddDbContext<TraineeDBContext>(
            options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
            );

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}