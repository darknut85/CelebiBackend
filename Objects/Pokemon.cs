namespace Objects
{
    public class Pokemon
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public int DexEntry { get; set; }

        public string? Classification { get; set; }

        public string? Type1 { get; set; }

        public string Type2 { get; set; } = string.Empty;

        public double Height { get; set; }

        public double Weight { get; set; }

        public string? PokedexEntry { get; set; }
    }
}