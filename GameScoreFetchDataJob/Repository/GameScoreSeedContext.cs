using GameScoreFetchDataJob.Models;
using Microsoft.EntityFrameworkCore;

namespace GameScoreFetchDataJob.Repository
{
    public class GameScoreSeedContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<PlatformGame> PlatformGames { get; set; }
        public DbSet<GenreGame> GenreGames { get; set; }
        public DbSet<Genre> Genres { get; set; }

        public GameScoreSeedContext(DbContextOptions<GameScoreSeedContext> options) : base(options)
        {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlatformGame>()
                .HasKey(x => new { x.GameId, x.PlatformId });

            modelBuilder.Entity<GenreGame>()
                .HasKey(x => new { x.GameId, x.GenreId });

            modelBuilder.Entity<Platform>()
                .HasKey(x => new { x.Id });

            modelBuilder.Entity<Genre>()
                .HasKey(g => new { g.Id });
        }
    }
}
