using Interfaces;
using Migrations;
using Objects;

namespace Services
{
    public class PokemonService : IPokemonService
    {
        private DataContext dataContext;

        public PokemonService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Pokemon Get(int id)
        {

            Pokemon pokemon = dataContext.Set<Pokemon>().FirstOrDefault(x => x.Id == id);
            if (pokemon != null)
            {
                return pokemon;
            }
            return new Pokemon();
        }

        public List<Pokemon> Get()
        {

            return dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry).ToList();
        }

        public List<Pokemon> Search(string query)
        {
            return dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry).Where(x => x.Name.Contains(query) || x.PokedexEntry.Contains(query) || x.Type1 == query || x.Type2.Contains(query)).ToList();
        }


        public Pokemon Create(Pokemon pokemon)
        {
            Pokemon? newPokemon = Get().Where(x => x.Name == pokemon.Name).FirstOrDefault();
            if (newPokemon != null)
                return new Pokemon();
            dataContext.Set<Pokemon>().Add(pokemon);
            SaveChanges();
            return pokemon;
        }

        public bool Delete(int id)
        {
            Pokemon pokemon = Get(id);
            if (pokemon.Id == 0) 
            {
                return false;
            }
            dataContext.Set<Pokemon>().Remove(pokemon);
            SaveChanges();
            return true;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            dataContext.Set<Pokemon>().Update(pokemon);
            Pokemon q = Get(pokemon.Id);
            if (q != null && q.Id == pokemon.Id && q.Id != 0)
            {
                dataContext.Set<Pokemon>().Update(pokemon);
                SaveChanges();
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