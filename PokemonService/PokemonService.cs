using Interfaces;
using Objects;

namespace Services
{
    public class PokemonService : IPokemonService
    {
        public Pokemon Get(int id)
        {
            Pokemon? pokemon = MakePokemonList().Where(x => x.Id == id).FirstOrDefault();
            if (pokemon == null)
                return new Pokemon();
            return pokemon;
        }

        public List<Pokemon> Get() => MakePokemonList();

        public List<Pokemon> Search(string query) => MakePokemonList().Where(x => x.Name.Contains(query) || x.PokedexEntry.Contains(query) || x.Type1 == query || x.Type2.Contains(query)).ToList();

        private List<Pokemon> MakePokemonList()
        {
            List<Pokemon>? pokemonList = new List<Pokemon>
            {
                new Pokemon()
                {
                    Id = 1, Name = "Bulbasaur", DexEntry = 1, Classification = "Seed Pokemon", Height = 0.7, Weight = 6.9, Type1 = "Grass", Type2 = "Poison",
                    PokedexEntry = "A strange seed was planted on its back at birth. The plant sprouts and grows with this Pokémon."
                },
                new Pokemon()
                {
                    Id = 2, Name = "Ivysaur", DexEntry = 2, Classification = "Seed Pokemon", Height = 1, Weight = 13, Type1 = "Grass", Type2 = "Poison",
                    PokedexEntry = "When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs."
                },
                new Pokemon()
                {
                    Id = 3, Name = "Venusaur", DexEntry = 3, Classification = "Seed Pokemon", Height = 2, Weight = 100, Type1 = "Grass", Type2 = "Poison",
                    PokedexEntry = "The plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight."
                },
                new Pokemon()
                {
                    Id = 4, Name = "Charmander", DexEntry = 4, Classification = "Lizard Pokemon", Height = 0.6, Weight = 8.5, Type1 = "Fire", Type2 = "",
                    PokedexEntry = "Obviously prefers hot places. When it rains, steam is said to spout from the tip of its tail."
                }
            };
            return pokemonList;
        }
    }
}