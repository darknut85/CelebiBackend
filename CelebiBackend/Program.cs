using Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Migrations;
using Objects;
using Services;
using System.Configuration;

namespace CelebiBackend
{
    public class Program
    {
        static void Main()
        {
            //@"Host=localhost;Username=postgres;Port=1700;Password=Soraheliatos2@;Database=pokemon"

            //IConfigurationRoot root = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();


            Pokedex pokedex = new();

            ServiceCollection serviceProvider = new();
            IServiceProvider provider = serviceProvider.AddDbContext<DataContext>
                (options => 
                {
                    options.UseNpgsql(pokedex.Configurating()); 
                }, ServiceLifetime.Transient)
                .AddScoped<IPokemonService, PokemonService>()
                .BuildServiceProvider();

            var pokemonService = provider.GetRequiredService<IPokemonService>();
            pokedex.MainMenu(pokemonService);
        }
    }

    public class Pokedex
    { 
        List<Pokemon>? pokemonList;

        public void MainMenu(IPokemonService pokemonService)
        {
            pokemonList = pokemonService.Get();
            while (true)
            {
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
                Console.Clear();
            }
        }

        public string Configurating()
        {
            var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddEnvironmentVariables();
            var config = builder.Build();

            return config.GetConnectionString("PostgreSqlConnection");
        }
    }
}