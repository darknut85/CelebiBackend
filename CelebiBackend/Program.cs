using Objects;
using Services;

namespace CelebiBackend
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Pokedex pokedex = new();
            pokedex.MainMenu();
        }
    }

    public class Pokedex
    { 
        List<Pokemon>? pokemonList;

        public void MainMenu()
        {
            PokemonService pokemonService = new();
            pokemonList = pokemonService.Get();
            while (true)
            {
                if (pokemonList != null)
                {
                    foreach (Pokemon pokemon in pokemonList)
                        Console.WriteLine($"{pokemon.Id}: {pokemon.Name}");
                    Console.WriteLine("Press a number to see the corresponding dex entry");

                    if (Int32.TryParse(Console.ReadLine(), out int dexnumber))
                    {
                        Console.Clear();
                        Pokemon? pokemon = pokemonList.Where(x => x.DexEntry == dexnumber).FirstOrDefault();
                        if (pokemon != null)
                        {
                            Console.WriteLine($"Dexnumber: {pokemon.DexEntry}");
                            Console.WriteLine($"Name: {pokemon.Name}");
                            Console.WriteLine($" Classification: {pokemon.Classification}");
                            Console.WriteLine($" Type: {pokemon.Type1}/{pokemon.Type2}");
                            Console.WriteLine($" Height: {pokemon.Height}");
                            Console.WriteLine($" Weight: {pokemon.Weight}\n");
                            Console.WriteLine($"Dex Entry: {pokemon.PokedexEntry}\n\n");
                        }
                        else
                            Console.WriteLine("The pokemon was not found.");
                        Console.WriteLine("Press any button to go back to the main page");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("List not found.");
                    Console.ReadKey();
                }
                Console.Clear();
            }
        }
    }
}