using Interfaces;
using Migrations;
using Objects;
using System.Diagnostics.CodeAnalysis;

namespace Services
{
    public class LevelupService : ILevelupService
    {
        private readonly DataContext dataContext;
        private readonly MoveService moveService;
        private readonly PokemonService pokemonService;

        public LevelupService(DataContext dataContext, MoveService moveService, 
            PokemonService pokemonService)
        {
            this.dataContext = dataContext;
            this.moveService = moveService;
            this.pokemonService = pokemonService;
        }

        public LevelupMove Get(int id)
        {

            LevelupMove? levelupMove = dataContext.Set<LevelupMove>().FirstOrDefault(x => x.Id == id);
            dataContext.Set<LevelupMove>().ToList();
            if (levelupMove != null)
            {
                return levelupMove;
            }
            return new LevelupMove();
        }

        public List<LevelupMove> Get()
        {
            List<LevelupMove> levelupMoveList = dataContext.Set<LevelupMove>().OrderBy(x => x.Level).ToList();
            dataContext.Set<LevelupMove>().ToList();
            return levelupMoveList;
        }
        
        public LevelupMove Create(LevelupMove levelupMove)
        {
            LevelupMove? newLevelupMove = Get().Where(
                x => x.MoveId == levelupMove.MoveId &&
                x.PokemonId == levelupMove.PokemonId &&
                x.Level == levelupMove.Level
                ).FirstOrDefault();
            
            if (newLevelupMove != null)
                return new LevelupMove();

            newLevelupMove = Get(levelupMove.Id);
            if(newLevelupMove.Id == levelupMove.Id)
            {
                return new LevelupMove();
            }

            dataContext.Set<LevelupMove>().Add(levelupMove);
            SaveChanges();
            return levelupMove;
        }

        public Delete Delete(int id)
        {
            Delete delete = new();
            LevelupMove levelupMove = Get(id);
            if (levelupMove.Id == 0)
            {
                delete.Deleted = false;
                return delete;
            }
            dataContext.Set<LevelupMove>().Remove(levelupMove);
            SaveChanges();
            delete.Deleted = true;
            return delete;
        }

        public LevelupMove Update(LevelupMove levelupMove)
        {
            dataContext.Set<LevelupMove>().Update(levelupMove);
            LevelupMove q = Get(levelupMove.Id);
            if (q != null)
            {
                if (q.Id == levelupMove.Id)
                {
                    if (q.Id != 0)
                    {
                        dataContext.Set<LevelupMove>().Update(levelupMove);
                        SaveChanges();
                        return levelupMove;
                    }
                }
            }
            return new LevelupMove();
        }

        [ExcludeFromCodeCoverage]
        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}
