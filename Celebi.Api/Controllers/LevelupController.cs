using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace Celebi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelupController : ControllerBase
    {
        readonly ILevelupService _levelupService;

        public LevelupController(ILevelupService levelupService)
        {
            _levelupService = levelupService;
        }

        [HttpGet]
        public IEnumerable<LevelupMove> Get()
        {
            return _levelupService.Get();
        }

        [HttpGet("id")]
        public LevelupMove Get(int id)
        {
            return _levelupService.Get(id);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(LevelupMove levelupMove)
        {
            _levelupService.Create(levelupMove);
            _levelupService.SaveChanges();
            return Ok(levelupMove);
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            Delete delete = _levelupService.Delete(id);
            _levelupService.SaveChanges();
            return Ok(delete);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Put(LevelupMove levelupMove)
        {
            _levelupService.Update(levelupMove);
            _levelupService.SaveChanges();
            return Ok(levelupMove);
        }
    }
}
