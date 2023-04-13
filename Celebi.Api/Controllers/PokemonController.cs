using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace Celebi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        readonly IPokemonService _pokemonService;

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

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Pokemon pokemon) 
        {
            _pokemonService.Create(pokemon);
            _pokemonService.SaveChanges();
            return Ok(pokemon);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("id")]
        public IActionResult Delete(int id) 
        { 
            Delete delete = _pokemonService.Delete(id);
            _pokemonService.SaveChanges();
            return Ok(delete);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Put(Pokemon pokemon) 
        { 
            _pokemonService.Update(pokemon);
            _pokemonService.SaveChanges();
            return Ok(pokemon);
        }
    }
}