using System.ComponentModel.DataAnnotations;

namespace COMP003B.Final.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int GameId { get; set; }
        [Range(0, 100)]
        public int RatingNum { get; set; }

        public virtual Game? Game { get; set; }
    }
}