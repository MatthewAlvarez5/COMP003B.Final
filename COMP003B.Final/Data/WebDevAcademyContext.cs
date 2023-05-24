using COMP003B.Final.Models;
using Microsoft.EntityFrameworkCore;


namespace COMP003B.FinalProject.Data
{
    public class WebDevAcademyContext : DbContext
    {
        public WebDevAcademyContext(DbContextOptions<WebDevAcademyContext> options)
            : base(options)
        {
        }

        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GamePlatform> GamePlatforms { get; set; }
        public DbSet<GameDeveloper> GameDevelopers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}