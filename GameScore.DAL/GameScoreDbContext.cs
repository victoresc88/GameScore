﻿using GameScore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameScore.DAL
{
	public class GameScoreDbContext : DbContext
	{
		public DbSet<Game> Games { get; set; }
		public DbSet<Platform> Platforms { get; set; }
		public DbSet<PlatformGame> PlatformGames { get; set; }
		public DbSet<GenreGame> GenreGames { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Score> Scores { get; set; }
		public DbSet<Rate> Rates { get; set; }
		public DbSet<User> Users { get; set; }

		public GameScoreDbContext(DbContextOptions<GameScoreDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PlatformGame>()
				 .HasKey(x => new { x.GameId, x.PlatformId });

			modelBuilder.Entity<GenreGame>()
				 .HasKey(x => new { x.GameId, x.GenreId });
		}
	}
}
