using System.Diagnostics.CodeAnalysis;

namespace Objects
{
    [ExcludeFromCodeCoverage]
    public class Move
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public double PowerPoints { get; set; }

        public double BasePower { get; set; }

        public double Accuracy { get; set; }

        public string BattleEffect { get; set; } = string.Empty;

        public double EffectRate { get; set; }

        public double Priority { get; set; }

        public string Target { get; set; } = string.Empty;
    }
}
