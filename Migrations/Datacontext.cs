using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Objects;
using System.Security.Cryptography;

namespace Migrations
{
    public class DataContext : IdentityDbContext
    {
        public DbSet<Pokemon> Pokemons { get; set; }

        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
            IConfiguration configuration = builder.Build();

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("conn1"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pokemon>().HasData(
                new Pokemon()
                {
                    Id = 1,
                    Name = "Bulbasaur",
                    DexEntry = 1,
                    Classification = "Seed Pokemon",
                    Height = 0.7,
                    Weight = 6.9,
                    Type1 = "Grass",
                    Type2 = "Poison",
                    PokedexEntry = "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon."
                },
                new Pokemon()
                {
                    Id = 2,
                    Name = "Ivysaur",
                    DexEntry = 2,
                    Classification = "Seed Pokemon",
                    Height = 1,
                    Weight = 13,
                    Type1 = "Grass",
                    Type2 = "Poison",
                    PokedexEntry = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs."
                },
                new Pokemon()
                {
                    Id = 3,
                    Name = "Venusaur",
                    DexEntry = 3,
                    Classification = "Seed Pokemon",
                    Height = 2,
                    Weight = 100,
                    Type1 = "Grass",
                    Type2 = "Poison",
                    PokedexEntry = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."
                },
                new Pokemon()
                {
                    Id = 4,
                    Name = "Charmander",
                    DexEntry = 4,
                    Classification = "Lizard Pokemon",
                    Height = 0.6,
                    Weight = 8.5,
                    Type1 = "Fire",
                    Type2 = "",
                    PokedexEntry = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail."
                }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "aec62267-a49a-400e-b4cc-305a6f08a6f2", NormalizedName = "ADMIN"},
                new IdentityRole() { Name = "User", ConcurrencyStamp = "b0c191f3-d89d-462e-8e7b-63afeffab947", NormalizedName = "USER" }
                );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser() { 
                    UserName = "NewUser", 
                    PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==", 
                    Email = "new.user@newUser.com",
                    NormalizedEmail = "NEW.USER@NEWUSER.COM",
                    NormalizedUserName = "NEWUSER",
                    EmailConfirmed = true
                });
        }
    }
}