using Interfaces;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using System.Diagnostics.CodeAnalysis;

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

            Pokemon? pokemon = dataContext.Set<Pokemon>().FirstOrDefault(x => x.Id == id);
            dataContext.Set<LevelupMove>().ToList();
            if (pokemon != null)
            {
                return pokemon;
            }
            return new Pokemon();
        }

        public List<Pokemon> Get()
        {
            List<Pokemon> pokemonList = dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry).ToList();
            dataContext.Set<LevelupMove>().ToList();
            return pokemonList;
        }

        public List<Pokemon> Search(string query)
        {
            return dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry)
                .Where(x => x.Name.Contains(query) || 
                x.PokedexEntry.Contains(query) ||
                x.Type1 == query || 
                x.Type2.Contains(query)).ToList();
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

        public Delete Delete(int id)
        {
            Delete delete = new();
            Pokemon pokemon = Get(id);
            if (pokemon.Id == 0) 
            {
                delete.Deleted = false;
                return delete;
            }
            dataContext.Set<Pokemon>().Remove(pokemon);
            SaveChanges();
            delete.Deleted = true;
            return delete;
        }

        public Pokemon Update(Pokemon pokemon)
        {
            dataContext.Set<Pokemon>().Update(pokemon);
            Pokemon q = Get(pokemon.Id);
            if (q != null)
            {
                if (q.Id == pokemon.Id)
                {
                    if (q.Id != 0)
                    {
                        dataContext.Set<Pokemon>().Update(pokemon);
                        SaveChanges();
                        return pokemon;
                    }
                }
            }
            return new Pokemon();
        }

        [ExcludeFromCodeCoverage]
        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}