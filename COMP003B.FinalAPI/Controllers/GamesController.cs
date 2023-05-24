using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class GamesController : Controller
    {
        private List<Game> _games = new List<Game>();
        public GamesController()
        {
            _games.Add(new Game { GameId = 1, GameName = "Red Dead Redemption 2", GameDescription = "Wild West Open World"});
            _games.Add(new Game { GameId = 2, GameName = "Call of Duty: Modern Warfare 2", GameDescription = "Military FPS" });
            _games.Add(new Game { GameId = 3, GameName = "Destiny 2", GameDescription = "Fantasy FPS" });
            _games.Add(new Game { GameId = 4, GameName = "Elden Ring", GameDescription = "Adventure, Action RPG" });
            _games.Add(new Game { GameId = 5, GameName = "Halo 2", GameDescription = "FPS" });
        }
        [HttpGet]
        public ActionResult<IEnumerable<Game>> GetAllGames()
        {
            return _games;
        }

        [HttpGet("Game{id}")]
        public ActionResult<Game> GetGameById(int id)
        {
            var game = _games.Find(s => s.GameId == id);
            if (game == null)
            {
                return NotFound();
            }
            return game;
        }

        // Create
        [HttpPost("Game{id}")]
        public ActionResult<Game> CreateGame(Game game)
        {
            //overwrites game id by max +1
            game.GameId = _games.Max(s => s.GameId) + 1;
            _games.Add(game);

            return CreatedAtAction(nameof(GetGameById), new { id = game.GameId }, game);
        }
        [HttpPut("Game{id}")]
        public IActionResult UpdateGame(int id, Game updatedGame)
        {
            var game = _games.Find(s => s.GameId == id);
            // Basically for loop searching for game if does, returns game
            if (game == null)
            {
                return BadRequest();
            }
            game.GameName = updatedGame.GameName;
            game.GameDescription = updatedGame.GameDescription;

            return NoContent();
        }

        //Delete
        [HttpDelete("Game{id}")]
        public IActionResult DeleteGame(int id)
        {
            var game = _games.Find(s => s.GameId == id);

            if (game == null)
            {
                return NotFound();
            }
            _games.Remove(game);

            return NoContent();
        }
    }
}
