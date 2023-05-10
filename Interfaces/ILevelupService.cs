using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface ILevelupService
    {
        List<LevelupMove> Get();

        LevelupMove Get(int id);

        LevelupMove Create(LevelupMove levelupMove);

        LevelupMove Update(LevelupMove levelupMove);

        Delete Delete(int id);

        void SaveChanges();
    }
}
