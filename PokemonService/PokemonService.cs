using Interfaces;
using Migrations;
using Objects;

namespace Services
{
    public class PokemonService : IPokemonService
    {
        private readonly DataContext dataContext;

        public PokemonService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Pokemon Get(int id)
        {
            return dataContext.Set<Pokemon>().FirstOrDefault(x => x.Id == id);
        }

        public List<Pokemon> Get()
        {
            return dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry).ToList();
        }

        public List<Pokemon> Search(string query)
        {
            return dataContext.Set<Pokemon>().Where(x => x.Name.Contains(query) || x.PokedexEntry.Contains(query) || x.Type1 == query || x.Type2.Contains(query)).ToList();
        }


        public Pokemon Create(Pokemon pokemon)
        {
            Pokemon? newPokemon = Get().Where(x => x.Name == pokemon.Name).FirstOrDefault();
            if (newPokemon != null)
                return new Pokemon();
            dataContext.Set<Pokemon>().Add(pokemon);
            return pokemon;
        }

        public bool Delete(int id)
        {
            var q = Get(id);
            dataContext.Set<Pokemon>().Remove(q);
            return true;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            var q = Get(pokemon.Id);
            if (q.Id == pokemon.Id)
            {
                dataContext.Set<Pokemon>().Update(pokemon);
                return pokemon;
            }
            return new Pokemon();
        }
        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}