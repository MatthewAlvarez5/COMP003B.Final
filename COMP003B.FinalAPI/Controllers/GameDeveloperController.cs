using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class GameDeveloperController : Controller
    {
        private List<GameDeveloper> _GameDevelopers = new List<GameDeveloper>();
        public GameDeveloperController()
        {
            _GameDevelopers.Add(new GameDeveloper { Id = 1, GameId = 1, DeveloperId = 5 });
            _GameDevelopers.Add(new GameDeveloper { Id = 2, GameId = 3, DeveloperId = 4 });
            _GameDevelopers.Add(new GameDeveloper { Id = 3, GameId = 4, DeveloperId = 3 });
            _GameDevelopers.Add(new GameDeveloper { Id = 4, GameId = 2, DeveloperId = 2 });
            _GameDevelopers.Add(new GameDeveloper { Id = 5, GameId = 5, DeveloperId = 1 });
        }
        [HttpGet]
        public ActionResult<IEnumerable<GameDeveloper>> GetAllGameDevelopers()
        {
            return _GameDevelopers;
        }

        [HttpGet("GameDeveloper{id}")]
        public ActionResult<GameDeveloper> GetGameDeveloperById(int id)
        {
            var GameDeveloper = _GameDevelopers.Find(s => s.Id == id);
            if (GameDeveloper == null)
            {
                return NotFound();
            }
            return GameDeveloper;
        }

        // Create
        [HttpPost("GameDeveloper{id}")]
        public ActionResult<GameDeveloper> CreateGameDeveloper(GameDeveloper GameDeveloper)
        {
            //overwrites GameDeveloper id by max +1
            GameDeveloper.Id = _GameDevelopers.Max(s => s.Id) + 1;
            _GameDevelopers.Add(GameDeveloper);

            return CreatedAtAction(nameof(GetGameDeveloperById), new { id = GameDeveloper.Id }, GameDeveloper);
        }
        [HttpPut("GameDeveloper{id}")]
        public IActionResult UpdateGameDeveloper(int id, GameDeveloper updatedGameDeveloper)
        {
            var GameDeveloper = _GameDevelopers.Find(s => s.Id == id);
            // Basically for loop searching for GameDeveloper if does, returns GameDeveloper
            if (GameDeveloper == null)
            {
                return BadRequest();
            }
            GameDeveloper.GameId = updatedGameDeveloper.GameId;
            GameDeveloper.DeveloperId = updatedGameDeveloper.DeveloperId;

            return NoContent();
        }

        //Delete
        [HttpDelete("GameDeveloper{id}")]
        public IActionResult DeleteGameDeveloper(int id)
        {
            var GameDeveloper = _GameDevelopers.Find(s => s.Id == id);

            if (GameDeveloper == null)
            {
                return NotFound();
            }
            _GameDevelopers.Remove(GameDeveloper);

            return NoContent();
        }
    }
}

