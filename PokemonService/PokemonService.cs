using Interfaces;
using Objects;

namespace Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IRepository repository;

        public PokemonService(IRepository repository)
        {
            this.repository = repository;
        }

        public Pokemon Get(int id)
        {
            return repository.Get(id);
        }

        public List<Pokemon> Get()
        {
            return repository.GetAll().ToList();
        }

        public List<Pokemon> Search(string query)
        {
            return repository.GetAll().Where(x => x.Name.Contains(query) || x.PokedexEntry.Contains(query) || x.Type1 == query || x.Type2.Contains(query)).ToList();
        }


        public Pokemon Create(Pokemon pokemon)
        {
            Pokemon? newPokemon = Get().Where(x => x.Name == pokemon.Name).FirstOrDefault();
            if (newPokemon != null)
                return new Pokemon();
            repository.Create(pokemon);
            return pokemon;
        }

        public bool Delete(int id)
        {
            Pokemon q = Get(id);
            repository.Delete(q);
            return true;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            var q = Get(pokemon.Id);
            if (q.Id == pokemon.Id)
            {
                repository.Update(pokemon);
                return pokemon;
            }
            return new Pokemon();
        }
        public void SaveChanges()
        {
            repository.SaveChanges();
        }
    }
}