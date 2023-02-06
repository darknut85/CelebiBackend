using Objects;

namespace Interfaces
{
    public interface IPokemonService
    {
        List<Pokemon> Get();

        Pokemon Get(int id);

        List<Pokemon> Search(string query);

        Pokemon Create(Pokemon pokemon);

        Pokemon Update(Pokemon pokemon);

        bool Delete(int id);

        void SaveChanges();
    }
}