using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using GameScore.SeedDB.Job.Mapping;
using GameScore.SeedDB.Job.Models;
using GameScore.Entities;
using Newtonsoft.Json;
using GameScore.DAL;

namespace GameScore.SeedDB.Job
{
	public class GameScoreSeedBusiness
	{
		private int NUMBER_OF_PAGES;
		private string m_url;
		private MapTools m_mapTools;

		private List<Game> m_gameList = new List<Game>();
		private List<Genre> m_genreList = new List<Genre>();
		private List<Platform> m_platformList = new List<Platform>();
		private List<GenreGame> m_genreGameList = new List<GenreGame>();
		private List<PlatformGame> m_platformGameList = new List<PlatformGame>();

		public GameScoreSeedBusiness(int startPage, int numberOfPages)
		{
			NUMBER_OF_PAGES = numberOfPages;
			m_url = $"https://api.rawg.io/api/games?page={startPage}";
			m_mapTools = new MapTools();
		}

		public async Task<List<GameApiPage>> GetGamesPageList()
		{
			var pageList = new List<GameApiPage>();

			using (var client = new HttpClient())
			{
				for (int i = 0; i < NUMBER_OF_PAGES; i++)
				{
					if (!string.IsNullOrEmpty(m_url))
					{
						var content = await client.GetStringAsync(m_url);
						var page = JsonConvert.DeserializeObject<GameApiPage>(content);
						pageList.Add(page);

						m_url = page.next;
						Console.WriteLine(page.next);
					}
				}
			}

			return pageList;
		}

		public void SeedApplicationModels(List<GameApiPage> pageList)
		{
			foreach (var page in pageList)
			{
				foreach (var apiGame in page.results)
				{
					AddGame(m_mapTools.MapApiGame(apiGame));
					AddPlatforms(m_mapTools.MapApiPlatforms(apiGame.platforms), m_gameList.Last());
					AddGenres(m_mapTools.MapApiGenres(apiGame.genres), m_gameList.Last());

					Console.WriteLine($"{m_gameList.Last().Name} added to list!");
				}
			}	
		}

		private void AddGame(Game game)
		{	
			m_gameList.Add(game);
		}

		private void AddPlatforms(List<Platform> platformList, Game game)
		{
			foreach (var platform in platformList)
			{
				if (!m_platformList.Any(p => p.OriginalId == platform.OriginalId))
					m_platformList.Add(platform);

				m_platformGameList.Add(new PlatformGame {
					Game = game,
					GameId = game.Id,
					Platform = m_platformList.Where(p => p.OriginalId == platform.OriginalId).First(),
					PlatformId = m_platformList.Where(p => p.OriginalId == platform.OriginalId).First().Id
				});
			}
		}

		private void AddGenres(List<Genre> genreList, Game game)
		{
			foreach (var genre in genreList)
			{
				if (!m_genreList.Any(p => p.OriginalId == genre.OriginalId))
					m_genreList.Add(genre);

				m_genreGameList.Add(new GenreGame {
					Game = game,
					GameId = game.Id,
					Genre = m_genreList.Where(g => g.OriginalId == genre.OriginalId).First(),
					GenreId = m_genreList.Where(g => g.OriginalId == genre.OriginalId).First().Id
				});
			}
		}

		public void SeedData()
		{
			var context = new GameScoreDbContextFactory().CreateDbContext();

			context.Games.AddRange(m_gameList);
			context.SaveChanges();

			context.Genres.AddRange(m_genreList);
			context.GenreGames.AddRange(m_genreGameList);
			context.SaveChanges();

			context.Platforms.AddRange(m_platformList);
			context.PlatformGames.AddRange(m_platformGameList);
			context.SaveChanges();
		}
	}
}
