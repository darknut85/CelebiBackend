using Objects;

namespace Interfaces
{
    public interface IMoveService
    {
        List<Move> Get();

        Move Get(int id);

        List<Move> Search(string query);

        Move Create(Move move);

        Move Update(Move move);

        Delete Delete(int id);

        void SaveChanges();
    }
}