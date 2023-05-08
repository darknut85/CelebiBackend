using Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Objects;

namespace Celebi.Api.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class MoveController : ControllerBase
    {
        readonly IMoveService _moveService;

        public MoveController(IMoveService moveService)
        {
            _moveService = moveService;
        }

        [HttpGet]
        public IEnumerable<Move> Get()
        {
            return _moveService.Get();
        }

        [HttpGet("id")]
        public Move Get(int id)
        {
            return _moveService.Get(id);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Create(Move move)
        {
            _moveService.Create(move);
            _moveService.SaveChanges();
            return Ok(move);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            Delete delete = _moveService.Delete(id);
            _moveService.SaveChanges();
            return Ok(delete);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult Put(Move move)
        {
            _moveService.Update(move);
            _moveService.SaveChanges();
            return Ok(move);
        }
    }
}
