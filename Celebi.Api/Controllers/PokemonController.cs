using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migrations;
using Objects;
using Services;

namespace Celebi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PokemonController : ControllerBase
    {
        PokemonService pokemonService;
        DataContext dataContext;

        public PokemonController(IPokemonService pokemonService, DbContext dataContext)
        {
            pokemonService = this.pokemonService;
            dataContext = this.dataContext;
        }

        [HttpGet]
        public IEnumerable<Pokemon> Get()
        {
            return pokemonService.Get();
        }

        [HttpGet("id")]
        public Pokemon Get(int id)
        {
            return pokemonService.Get(id);
        }

        [HttpPost]
        public void Create(Pokemon pokemon) 
        { 
            pokemonService.Create(pokemon);
            pokemonService.SaveChanges();
        }

        [HttpDelete("id")]
        public void Delete(int id) 
        { 
            pokemonService.Delete(id);
            pokemonService.SaveChanges();
        }

        [HttpPut]
        public void Put(Pokemon pokemon) 
        { 
            pokemonService.Update(pokemon);
            pokemonService.SaveChanges();
        }
    }
}