using System.Diagnostics.CodeAnalysis;

namespace Objects
{
    [ExcludeFromCodeCoverage]
    public class Pokemon
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int DexEntry { get; set; }

        public string Classification { get; set; } = string.Empty;

        public string Type1 { get; set; } = string.Empty;

        public string Type2 { get; set; } = string.Empty;

        public double Height { get; set; }

        public double Weight { get; set; }

        public string PokedexEntry { get; set; } = string.Empty;

        public double GrowthRate { get; set; }

        public double HP { get; set; }

        public double ATK { get; set; }

        public double DEF { get; set; }

        public double SPATK { get; set; }

        public double SPDEF { get; set; }

        public double SPD { get; set; }

        public double HPEV { get; set; }

        public double ATKEV { get; set; }

        public double DEFEV { get; set; }

        public double SPATKEV { get; set; }

        public double SPDEFEV { get; set; }

        public double SPDEV { get; set; }


    }
}