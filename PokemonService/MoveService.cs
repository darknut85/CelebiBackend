using Interfaces;
using Migrations;
using Objects;
using System.Diagnostics.CodeAnalysis;

namespace Services
{
    public class MoveService : IMoveService
    {
        private readonly DataContext dataContext;

        public MoveService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Move Get(int id)
        {

            Move? move = dataContext.Set<Move>().FirstOrDefault(x => x.Id == id);
            if (move != null)
            {
                return move;
            }
            return new Move();
        }

        public List<Move> Get()
        {
            List<Move> moveList =  dataContext.Set<Move>().OrderBy(x => x.Name).ToList();
            dataContext.Set<LevelupMove>().ToList();
            return moveList;
        }

        public List<Move> Search(string query)
        {
            return dataContext.Set<Move>().OrderBy(x => x.Name)
                .Where(x => x.Name.Contains(query) ||
                x.Type == query).ToList();
        }

        public Move Create(Move move)
        {
            Move? newMove = Get().Where(x => x.Name == move.Name).FirstOrDefault();
            if (newMove != null)
                return new Move();
            dataContext.Set<Move>().Add(move);
            SaveChanges();
            return move;
        }

        public Delete Delete(int id)
        {
            Delete delete = new();
            Move move = Get(id);
            if (move.Id == 0) 
            {
                delete.Deleted = false;
                return delete;
            }
            dataContext.Set<Move>().Remove(move);
            SaveChanges();
            delete.Deleted = true;
            return delete;
        }

        public Move Update(Move move)
        {
            dataContext.Set<Move>().Update(move);
            Move q = Get(move.Id);
            if (q != null)
            {
                if (q.Id == move.Id)
                {
                    if (q.Id != 0)
                    {
                        dataContext.Set<Move>().Update(move);
                        SaveChanges();
                        return move;
                    }
                }
            }
            return new Move();
        }

        [ExcludeFromCodeCoverage]
        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}