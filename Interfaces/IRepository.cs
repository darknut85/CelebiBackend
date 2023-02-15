using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IRepository
    {
        IEnumerable<Pokemon> GetAll();

        Pokemon Get(int id);

        void Create(Pokemon pokemon);

        void Update(Pokemon pokemon);

        void Delete(Pokemon pokemon);

        void SaveChanges();
    }
}
