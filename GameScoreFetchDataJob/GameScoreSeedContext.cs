using GameScoreFetchDataJob.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob
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
