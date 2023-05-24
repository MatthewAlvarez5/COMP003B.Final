using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class GamePlatformController : Controller
    {
        private List<GamePlatform> _GamePlatforms = new List<GamePlatform>();
        public GamePlatformController()
        {
            _GamePlatforms.Add(new GamePlatform { Id = 1, GameId = 5, PlatformId = 5 });
            _GamePlatforms.Add(new GamePlatform { Id = 2, GameId = 2, PlatformId = 3 });
            _GamePlatforms.Add(new GamePlatform { Id = 3, GameId = 7, PlatformId = 4 });
            _GamePlatforms.Add(new GamePlatform { Id = 4, GameId = 4, PlatformId = 5 });
            _GamePlatforms.Add(new GamePlatform { Id = 5, GameId = 3, PlatformId = 4 });
        }
        [HttpGet]
        public ActionResult<IEnumerable<GamePlatform>> GetAllGamePlatforms()
        {
            return _GamePlatforms;
        }

        [HttpGet("GamePlatform{id}")]
        public ActionResult<GamePlatform> GetGamePlatformById(int id)
        {
            var GamePlatform = _GamePlatforms.Find(s => s.Id == id);
            if (GamePlatform == null)
            {
                return NotFound();
            }
            return GamePlatform;
        }

        // Create
        [HttpPost("GamePlatform{id}")]
        public ActionResult<GamePlatform> CreateGamePlatform(GamePlatform GamePlatform)
        {
            //overwrites GamePlatform id by max +1
            GamePlatform.Id = _GamePlatforms.Max(s => s.Id) + 1;
            _GamePlatforms.Add(GamePlatform);

            return CreatedAtAction(nameof(GetGamePlatformById), new { id = GamePlatform.Id }, GamePlatform);
        }
        [HttpPut("GamePlatform{id}")]
        public IActionResult UpdateGamePlatform(int id, GamePlatform updatedGamePlatform)
        {
            var GamePlatform = _GamePlatforms.Find(s => s.Id == id);
            // Basically for loop searching for GamePlatform if does, returns GamePlatform
            if (GamePlatform == null)
            {
                return BadRequest();
            }
            GamePlatform.GameId = updatedGamePlatform.GameId;
            GamePlatform.PlatformId = updatedGamePlatform.PlatformId;

            return NoContent();
        }

        //Delete
        [HttpDelete("GamePlatform{id}")]
        public IActionResult DeleteGamePlatform(int id)
        {
            var GamePlatform = _GamePlatforms.Find(s => s.Id == id);

            if (GamePlatform == null)
            {
                return NotFound();
            }
            _GamePlatforms.Remove(GamePlatform);

            return NoContent();
        }
    }
}
