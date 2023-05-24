
using System.ComponentModel.DataAnnotations;

namespace COMP003B.Final.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameDescription { get; set; }
    }
}