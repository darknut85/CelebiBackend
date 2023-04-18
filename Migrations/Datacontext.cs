using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Objects;

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
                    PokedexEntry = "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon.",
                    HP = 45,
                    ATK = 49,
                    DEF = 49,
                    SPATK = 65,
                    SPDEF = 65,
                    SPD = 45,
                    HPEV = 45,
                    ATKEV = 49,
                    DEFEV = 49,
                    SPATKEV = 65,
                    SPDEFEV = 65,
                    SPDEV = 45,
                    GrowthRate = 1059860
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
                    PokedexEntry = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.",
                    HP = 60,
                    ATK = 62,
                    DEF = 63,
                    SPATK = 80,
                    SPDEF = 80,
                    SPD = 60,
                    HPEV = 60,
                    ATKEV = 62,
                    DEFEV = 63,
                    SPATKEV = 80,
                    SPDEFEV = 80,
                    SPDEV = 60,
                    GrowthRate = 1059860
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
                    PokedexEntry = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.",
                    HP = 80,
                    ATK = 82,
                    DEF = 83,
                    SPATK = 100,
                    SPDEF = 100,
                    SPD = 80,
                    HPEV = 80,
                    ATKEV = 82,
                    DEFEV = 83,
                    SPATKEV = 100,
                    SPDEFEV = 100,
                    SPDEV = 80,
                    GrowthRate = 1059860
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
                    PokedexEntry = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail.",
                    HP = 39,
                    ATK = 52,
                    DEF = 42,
                    SPATK = 50,
                    SPDEF = 50,
                    SPD = 65,
                    HPEV = 39,
                    ATKEV = 52,
                    DEFEV = 42,
                    SPATKEV = 50,
                    SPDEFEV = 50,
                    SPDEV = 65,
                    GrowthRate = 1059860
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