using Objects;

namespace Interfaces
{
    public interface IMoveService
    {
        List<Move> Get();

        Move Get(int id);

        List<Move> Search(string query);

        Pokemon Create(Move move);

        Pokemon Update(Move move);

        Delete Delete(int id);

        void SaveChanges();
    }
}