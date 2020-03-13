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

		public void AddGames(List<Game> gameList)
		{
			_context.Games.AddRange(gameList);
			SaveChanges();
		}

		public void AddPlatforms(List<Platform> platformList)
		{
			_context.Platforms.AddRange(platformList);
			SaveChanges();
		}

		public void AddGenres(List<Genre> genreList)
		{
			_context.Genres.AddRange(genreList);
			SaveChanges();
		}

		public void AddPlatformGames(List<PlatformGame> platformGameList)
		{
			_context.PlatformGames.AddRange(platformGameList);
			SaveChanges();
		}

		public void AddGenreGames(List<GenreGame> genreGameList)
		{
			_context.GenreGames.AddRange(genreGameList);
			SaveChanges();
		}

		private void SaveChanges()
		{
			try
			{
				_context.SaveChanges();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
