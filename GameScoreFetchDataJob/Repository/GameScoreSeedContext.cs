using GameScoreFetchDataJob.Models;
using Microsoft.EntityFrameworkCore;

namespace GameScoreFetchDataJob.Repository
{
    public class GameScoreSeedContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Platform> Platforms { get; set; }

        public GameScoreSeedContext(DbContextOptions<GameScoreSeedContext> options) : base(options)
        {
        }
    }
}
