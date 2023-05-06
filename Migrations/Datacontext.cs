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
                    GrowthRate = 1059860,
                    CaptureRate = 45
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
                    GrowthRate = 1059860,
                    CaptureRate = 45
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
                    GrowthRate = 1059860,
                    CaptureRate = 45
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
                    GrowthRate = 1059860,
                    CaptureRate = 45
                },
                new Pokemon()
                {
                    Id = 5,
                    Name = "Charmeleon",
                    DexEntry = 5,
                    Classification = "Flame Pokemon",
                    Height = 1.1,
                    Weight = 19,
                    Type1 = "Fire",
                    Type2 = "",
                    PokedexEntry = "When it swings its burning tail, it elevates the temperature to unbearably high levels.",
                    HP = 58,
                    ATK = 64,
                    DEF = 58,
                    SPATK = 65,
                    SPDEF = 65,
                    SPD = 80,
                    HPEV = 58,
                    ATKEV = 64,
                    DEFEV = 58,
                    SPATKEV = 65,
                    SPDEFEV = 65,
                    SPDEV = 80,
                    GrowthRate = 1059860,
                    CaptureRate = 45
                }
                );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name = "Admin", ConcurrencyStamp = "aec62267-a49a-400e-b4cc-305a6f08a6f2", NormalizedName = "ADMIN" },
                new IdentityRole() { Name = "User", ConcurrencyStamp = "b0c191f3-d89d-462e-8e7b-63afeffab947", NormalizedName = "USER" }
                );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser()
                {
                    UserName = "NewUser",
                    PasswordHash = "AQAAAAEAACcQAAAAEDwVLvLsPe2ydTBJ4DS5w+fMM9MX5pzjNRvjo/105TDE2LMp8rxKsrAAwc4Dh/yQFg==",
                    Email = "new.user@newUser.com",
                    NormalizedEmail = "NEW.USER@NEWUSER.COM",
                    NormalizedUserName = "NEWUSER",
                    EmailConfirmed = true
                },
                new IdentityUser()
                {
                    UserName = "RealAdmin",
                    PasswordHash = "AQAAAAEAACcQAAAAECB/+o448AU5IIFcCRY3zS4TONAqem2LTyezhBXOcUPu/FIgL4itYZmtRiUbxT4kgg==",
                    Email = "reall.admin@admin.eal",
                    NormalizedEmail = "REALL.ADMIN@ADMIN.EAL",
                    NormalizedUserName = "REALADMIN",
                    EmailConfirmed = true
                });
            modelBuilder.Entity<Move>().HasData(
                new Move()
                {
                    Id = 1,
                    Name = "Tackle",
                    Type = "Normal",
                    PowerPoints = 35,
                    BasePower = 35,
                    Accuracy = 95,
                    BattleEffect = "A NORMAL-type attack. Many Pokémon know this attack right from the start.",
                    EffectRate = 0,
                    Priority = 0,
                    Target = "selected target"
                },
                new Move()
                {
                    Id = 2,
                    Name = "Scratch",
                    Type = "Normal",
                    PowerPoints = 40,
                    BasePower = 35,
                    Accuracy = 100,
                    BattleEffect = "A NORMAL-type attack. Sharp claws are used to inflict damage on the target.",
                    EffectRate = 0,
                    Priority = 0,
                    Target = "selected target"
                },
                new Move()
                {
                    Id = 3,
                    Name = "Growl",
                    Type = "Normal",
                    PowerPoints = 40,
                    BasePower = 0,
                    Accuracy = 100,
                    BattleEffect = "A technique that lowers the target's ATTACK power. Can normally be used up to six times.",
                    EffectRate = 0,
                    Priority = 0,
                    Target = "All opponent Pokémon in range"
                },
                new Move()
                {
                    Id = 4,
                    Name = "Tail Whip",
                    Type = "Normal",
                    PowerPoints = 30,
                    BasePower = 0,
                    Accuracy = 100,
                    BattleEffect = "A technique that lowers the target's DEFENSE. Useful against tough, armored Pokémon.",
                    EffectRate = 0,
                    Priority = 0,
                    Target = "All opponent Pokémon in range"
                });
        }
    }
}