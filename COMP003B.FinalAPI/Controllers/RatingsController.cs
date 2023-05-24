using COMP003B.FinalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace COMP003B.FinalAPI.Controllers
{
    public class RatingsController : Controller
    {
        private List<Rating> _Ratings = new List<Rating>();
        public RatingsController()
        {
            _Ratings.Add(new Rating { RatingId = 1, RatingNum = 92, GameId= 1 });
            _Ratings.Add(new Rating { RatingId = 2, RatingNum = 87, GameId = 2 });
            _Ratings.Add(new Rating { RatingId = 3, RatingNum = 74, GameId = 3 });
            _Ratings.Add(new Rating { RatingId = 4, RatingNum = 97, GameId = 4 });
            _Ratings.Add(new Rating { RatingId = 5, RatingNum = 90, GameId = 5 });
        }
        [HttpGet]
        public ActionResult<IEnumerable<Rating>> GetAllRatings()
        {
            return _Ratings;
        }

        [HttpGet("Rating{id}")]
        public ActionResult<Rating> GetRatingById(int id)
        {
            var Rating = _Ratings.Find(s => s.RatingId == id);
            if (Rating == null)
            {
                return NotFound();
            }
            return Rating;
        }

        // Create
        [HttpPost("Rating{id}")]
        public ActionResult<Rating> CreateRating(Rating Rating)
        {
            //overwrites Rating id by max +1
            Rating.RatingId = _Ratings.Max(s => s.RatingId) + 1;
            _Ratings.Add(Rating);

            return CreatedAtAction(nameof(GetRatingById), new { id = Rating.RatingId }, Rating);
        }
        [HttpPut("Rating{id}")]
        public IActionResult UpdateRating(int id, Rating updatedRating)
        {
            var Rating = _Ratings.Find(s => s.RatingId == id);
            // Basically for loop searching for Rating if does, returns Rating
            if (Rating == null)
            {
                return BadRequest();
            }
            Rating.RatingNum = updatedRating.RatingNum;
            Rating.GameId = updatedRating.GameId;

            return NoContent();
        }

        //Delete
        [HttpDelete("Rating{id}")]
        public IActionResult DeleteRating(int id)
        {
            var Rating = _Ratings.Find(s => s.RatingId == id);

            if (Rating == null)
            {
                return NotFound();
            }
            _Ratings.Remove(Rating);

            return NoContent();
        }
    }
}