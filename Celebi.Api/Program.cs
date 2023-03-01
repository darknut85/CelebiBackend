using Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Celebi.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors();

            builder.Services.AddControllers();
            builder.Services.AddAuthentication(AuthOptions =>
            {
                AuthOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                AuthOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwtOptions =>
            {
                var key = builder.Configuration.GetValue<string>("JwtConfig:key");
                var keyBytes = Encoding.ASCII.GetBytes(key);
                jwtOptions.SaveToken = true;
                jwtOptions.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
                    ValidateLifetime = true,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ClockSkew = TimeSpan.Zero
                };
            });

            builder.Services.AddDbContext<DataContext>
                (options => { options.UseNpgsql(builder.Configuration.GetConnectionString("conn1")); }, ServiceLifetime.Transient);
            builder.Services.AddScoped<IPokemonService, PokemonService>();
            builder.Services.AddSingleton(typeof(IJwtTokenManager), typeof(JwtTokenManager));

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

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}