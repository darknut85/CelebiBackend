using Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IActionResult Create(Pokemon pokemon) 
        {
            _pokemonService.Create(pokemon);
            _pokemonService.SaveChanges();
            return Ok(pokemon);
        }

        [HttpDelete("id")]
        [Authorize]
        public IActionResult Delete(int id) 
        { 
            _pokemonService.Delete(id);
            _pokemonService.SaveChanges();
            return Ok($"{id} deleted");
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put(Pokemon pokemon) 
        { 
            _pokemonService.Update(pokemon);
            _pokemonService.SaveChanges();
            return Ok(pokemon);
        }
    }
}