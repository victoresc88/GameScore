using GameScoreFetchDataJob.Models;
using Microsoft.EntityFrameworkCore;
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
			_context.Games.Add(game);
			SaveChanges();
		}

		public void AddPlatformGame(List<Platform> platformList, Game game)
		{
			foreach (var platform in platformList)
			{
				if (!_context.Platforms.Any(p => p.Id == platform.Id))
				{
					_context.Platforms.Add(platform);
					SaveChanges();
				}
					
				_context.PlatformGames.Add(new PlatformGame {
					Game = game,
					GameId = game.Id,
					Platform = platform,
					PlatformId = platform.Id
				});

				SaveChanges();
			}

			
		}

		public void AddGenreGame(List<Genre> genreList, Game game)
		{
			foreach (var genre in genreList)
			{
				if (!_context.Genres.Any(g => g.Id == genre.Id))
				{
					_context.Genres.Add(genre);
					SaveChanges();
				}

				_context.GenreGames.Add(new GenreGame {
					Game = game,
					GameId = game.Id,
					Genre = genre,
					GenreId = genre.Id
				});

				SaveChanges();
			}

			
		}

		private void SaveChanges()
		{
			try
			{
				using (var transaction = _context.Database.BeginTransaction())
				{
					_context.SaveChanges();

					transaction.Commit();
				}
					
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex);
			}
		}
	}
}
