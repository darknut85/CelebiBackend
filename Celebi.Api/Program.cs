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

            builder.Services.AddCors();//(options =>
            //{
            //    options.AddPolicy("AllowSpecificOrigins",
            //                      policy =>
            //                      {
            //                          policy.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost");
            //                          //policy.WithOrigins("http://localhost:7282/api/Pokemon");
            //                          //policy.WithOrigins("http://localhost:4200/api/Pokemon");
            //                      });
            //});

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataContext>
                (options => { options.UseNpgsql(@"Host=localhost;Username=postgres;Port=1700;Password=Soraheliatos2@;Database=pokemon"); }, ServiceLifetime.Transient);
            builder.Services.AddScoped<IPokemonService, PokemonService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseAuthentication();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(x =>
            {
                x.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
            //app.UseCors(MyAllowSpecificOrigins);
            //.SetIsOriginAllowed(origin => true)
            //.AllowCredentials());

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}