using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class DeveloperController : Controller
    {
        private List<Developer> _Developers = new List<Developer>();
        public DeveloperController()
        {
            _Developers.Add(new Developer { DeveloperId = 1, DeveloperName = "Rockstar"});
            _Developers.Add(new Developer { DeveloperId = 2, DeveloperName = "Bethesda" });
            _Developers.Add(new Developer { DeveloperId = 3, DeveloperName = "InfinityWard" });
            _Developers.Add(new Developer { DeveloperId = 4, DeveloperName = "Bungie" });
            _Developers.Add(new Developer { DeveloperId = 5, DeveloperName = "FromSoftware Inc." });
        }
        [HttpGet]
        public ActionResult<IEnumerable<Developer>> GetAllDevelopers()
        {
            return _Developers;
        }

        [HttpGet("Developer{id}")]
        public ActionResult<Developer> GetDeveloperById(int id)
        {
            var developer = _Developers.Find(s => s.DeveloperId == id);
            if (developer == null)
            {
                return NotFound();
            }
            return developer;
        }

        // Create
        [HttpPost("Developer{id}")]
        public ActionResult<Developer> CreateDeveloper(Developer Developer)
        {
            //overwrites Developer id by max +1
            Developer.DeveloperId = _Developers.Max(s => s.DeveloperId) + 1;
            _Developers.Add(Developer);

            return CreatedAtAction(nameof(GetDeveloperById), new { id = Developer.DeveloperId }, Developer);
        }
        [HttpPut("Developer{id}")]
        public IActionResult UpdateDeveloper(int id, Developer updatedDeveloper)
        {
            var Developer = _Developers.Find(s => s.DeveloperId == id);
            // Basically for loop searching for Developer if does, returns Developer
            if (Developer == null)
            {
                return BadRequest();
            }
            Developer.DeveloperName = updatedDeveloper.DeveloperName;

            return NoContent();
        }

        //Delete
        [HttpDelete("Developer{id}")]
        public IActionResult DeleteDeveloper(int id)
        {
            var Developer = _Developers.Find(s => s.DeveloperId == id);

            if (Developer == null)
            {
                return NotFound();
            }
            _Developers.Remove(Developer);

            return NoContent();
        }
    }
}
