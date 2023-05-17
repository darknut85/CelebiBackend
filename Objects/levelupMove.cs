using System.Diagnostics.CodeAnalysis;

namespace Objects
{
    [ExcludeFromCodeCoverage]
    public class LevelupMove
    {
        public int Id { get; set; }

        public int Level { get; set; }

        //Navigation Properties
        public int PokemonId { get; set; }

        public int MoveId { get; set; }
    }
}
