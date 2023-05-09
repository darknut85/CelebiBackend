using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Objects
{
    public class LevelupMove
    {
        public int Id { get; set; }

        public int Level { get; set; }

        //Navigation Properties
        public int PokemonId { get; set; }
    }
}
