namespace COMP003B.Final.Models
{
    public class Genre
    {
        public int GenreId { get; set; } // Database won't allow this to be placed in another entity >:(((( Frustrating
        public string GenreName { get; set; }
        public string GenreDescription { get; set; }
    }
}