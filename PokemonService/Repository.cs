using Interfaces;
using Migrations;
using Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Repository: IRepository
    {
        private DataContext dataContext;
        public Repository( DataContext dataContext) 
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<Pokemon> GetAll()
        {
            return dataContext.Set<Pokemon>().OrderBy(x => x.DexEntry);
        }

        public Pokemon Get(int id) 
        {
            return dataContext.Set<Pokemon>().FirstOrDefault(x => x.Id == id);
        }

        public void Create(Pokemon pokemon)
        {
            dataContext.Set<Pokemon>().Add(pokemon);
        }

        public void Update(Pokemon pokemon)
        {
            dataContext.Set<Pokemon>().Update(pokemon);
        }

        public void Delete(Pokemon pokemon)
        {
            dataContext.Set<Pokemon>().Remove(pokemon);
        }

        public void SaveChanges()
        {
            dataContext.SaveChanges();
        }
    }
}
