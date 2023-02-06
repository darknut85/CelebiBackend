using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace Celebi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return _pokemonService.Get();
        }

        [HttpGet("id")]
        public Pokemon Get(int id)
        {
            return _pokemonService.Get(id);
        }

        [HttpPost]
        public void Create(Pokemon pokemon) 
        { 
            _pokemonService.Create(pokemon);
            _pokemonService.SaveChanges();
        }

        [HttpDelete("id")]
        public void Delete(int id) 
        { 
            _pokemonService.Delete(id);
            _pokemonService.SaveChanges();
        }

        [HttpPut]
        public void Put(Pokemon pokemon) 
        { 
            _pokemonService.Update(pokemon);
            _pokemonService.SaveChanges();
        }
    }
}