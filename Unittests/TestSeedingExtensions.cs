using Migrations;
using Objects;
using TestSupport.EfHelpers;

namespace Unittests
{
    public static class TestSeedingExtensions
    {
        public static void PokemonSetup(this DataContext dataContext)
        {
            List<Pokemon> pokemons = new List<Pokemon>()
            {
                new Pokemon() 
                { Name = "Mewtwo", DexEntry = 150, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." },
                new Pokemon() 
                { Name = "Mew", DexEntry = 151, Type1 = "Psychic", Type2 = "", Height = 2, Weight = 2, Classification = "???", PokedexEntry = "..." }
            };

            dataContext.AddRange(pokemons);
            dataContext.SaveChanges();
        }

        public static void DefaultSetup(this DataContext context)
        {
            context.Database.EnsureClean();
            context.PokemonSetup();
            context.ChangeTracker.Clear();
        }
    }
}
