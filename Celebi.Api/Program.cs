using Interfaces;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;

namespace Celebi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>
                (options => { options.UseNpgsql(@"Host=localhost;Username=postgres;Port=1700;Password=Soraheliatos2@;Database=pokemon"); }, ServiceLifetime.Transient);
            builder.Services.AddScoped<IPokemonService, PokemonService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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