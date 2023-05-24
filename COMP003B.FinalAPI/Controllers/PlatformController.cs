using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class PlatformController : Controller
    {
        private List<Platform> _Platforms = new List<Platform>();
        public PlatformController()
        {
            _Platforms.Add(new Platform { PlatformId = 1, PlatformName = "Playstation 5", PlatformType = "Console" });
            _Platforms.Add(new Platform { PlatformId = 2, PlatformName = "Xbox Series X", PlatformType = "Console" });
            _Platforms.Add(new Platform { PlatformId = 3, PlatformName = "Xbox Series S", PlatformType = "Console" });
            _Platforms.Add(new Platform { PlatformId = 4, PlatformName = "PC", PlatformType = "Personal Computer" });
            _Platforms.Add(new Platform { PlatformId = 5, PlatformName = "Playstation Portable (PSP)", PlatformType = "Handheld Console" });
        }
        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms()
        {
            return _Platforms;
        }

        [HttpGet("Platform{id}")]
        public ActionResult<Platform> GetPlatformById(int id)
        {
            var platform = _Platforms.Find(s => s.PlatformId == id);
            if (platform == null)
            {
                return NotFound();
            }
            return platform;
        }

        // Create
        [HttpPost("Platform{id}")]
        public ActionResult<Platform> CreatePlatform(Platform Platform)
        {
            //overwrites Platform id by max +1
            Platform.PlatformId = _Platforms.Max(s => s.PlatformId) + 1;
            _Platforms.Add(Platform);

            return CreatedAtAction(nameof(GetPlatformById), new { id = Platform.PlatformId }, Platform);
        }
        [HttpPut("Platform{id}")]
        public IActionResult UpdatePlatform(int id, Platform updatedPlatform)
        {
            var Platform = _Platforms.Find(s => s.PlatformId == id);
            // Basically for loop searching for Platform if does, returns Platform
            if (Platform == null)
            {
                return BadRequest();
            }
            Platform.PlatformName = updatedPlatform.PlatformName;
            Platform.PlatformType = updatedPlatform.PlatformType;

            return NoContent();
        }

        //Delete
        [HttpDelete("Platform{id}")]
        public IActionResult DeletePlatform(int id)
        {
            var Platform = _Platforms.Find(s => s.PlatformId == id);

            if (Platform == null)
            {
                return NotFound();
            }
            _Platforms.Remove(Platform);

            return NoContent();
        }
    }
}
