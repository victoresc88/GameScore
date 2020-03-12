using GameScoreFetchDataJob.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameScoreFetchDataJob.Repository
{
	public class GameScoreSeedRepository : IGameScoreSeedRepository
	{
		private GameScoreSeedContext _context;

		public GameScoreSeedRepository()
		{
			_context = new GameScoreSeedContextFactory().CreateDbContext();
		}

		public void AddGame(Game game)
		{
			if (!_context.Games.Any(g => g.OriginalId == game.OriginalId))
			{
				_context.Games.Add(game);
				SaveChanges();
			}
		}

		public void AddPlatformGame(List<Platform> platformList, Game game)
		{
			foreach (var platform in platformList)
			{
				if (!_context.Platforms.Any(p => p.OriginalId == platform.OriginalId))
				{
					_context.Platforms.Add(platform);
					SaveChanges();
				}
					
				_context.PlatformGames.Add(new PlatformGame {
					Game = game,
					GameId = game.Id,
					Platform = _context.Platforms.Where(p => p.OriginalId == platform.OriginalId).First(),
					PlatformId = _context.Platforms.Where(p => p.OriginalId == platform.OriginalId).First().Id
				});
				SaveChanges();
			}
		}

		public void AddGenreGame(List<Genre> genreList, Game game)
		{
			foreach (var genre in genreList)
			{
				if (!_context.Genres.Any(g => g.OriginalId == genre.OriginalId))
				{
					_context.Genres.Add(genre);
					SaveChanges();
				}
				
				_context.GenreGames.Add(new GenreGame {
					Game = game,
					GameId = game.Id,
					Genre = _context.Genres.Where(g => g.OriginalId == genre.OriginalId).First(),
					GenreId = _context.Genres.Where(g => g.OriginalId == genre.OriginalId).First().Id
				});
				SaveChanges();
			}
		}

		private void SaveChanges()
		{
			using (var transaction = _context.Database.BeginTransaction())
			{
				try
				{
					_context.SaveChanges();
					transaction.Commit();
				}
				catch (Exception ex)
				{
					transaction.Rollback();
					Console.WriteLine(ex);
				}
			}
		}
	}
}
