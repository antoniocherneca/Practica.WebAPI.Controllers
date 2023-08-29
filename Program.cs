using Microsoft.EntityFrameworkCore;
using Practica.WebAPI.Controllers.Data;
using Practica.WebAPI.Controllers.Data.Interfaces;
using Practica.WebAPI.Controllers.Data.Repositories;

namespace Practica.WebAPI.Controllers
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

            builder.Services.AddDbContext<MoviesDbContext>(options =>
            {
                options.UseInMemoryDatabase("MoviesDb");
            });
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();

            builder.Services.AddDbContext<PartnersDbContext>(options =>
            {
                options.UseInMemoryDatabase("PartnersDb");
            });
            builder.Services.AddScoped<IPartnerRepository, PartnerRepository>();

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