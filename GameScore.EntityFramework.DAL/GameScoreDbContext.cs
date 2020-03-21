
using GameScore.EntityFramework.BL;
using Microsoft.EntityFrameworkCore;

namespace GameScore.EntityFramework.DAL
{
    public class GameScoreDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformGame> PlatformGames { get; set; }
        public DbSet<GenreGame> GenreGames { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public GameScoreDbContext(DbContextOptions<GameScoreDbContext> options) : base(options)
        {        
        }
    }
}
