using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.Mapping;
using GameScoreFetchDataJob.Repository;
using GameScoreFetchDataJob.ApiModels;

using Newtonsoft.Json;

namespace GameScoreFetchDataJob
{
	public class GameScoreSeedBusiness
	{
		private IGameScoreSeedRepository _gameScoreSeedRepository;

		private List<Game> m_gameList = new List<Game>();
		private List<Platform> m_platformList = new List<Platform>();
		private List<Genre> m_genreList = new List<Genre>();
		private List<PlatformGame> m_platformGameList = new List<PlatformGame>();
		private List<GenreGame> m_genreGameList = new List<GenreGame>();

		public GameScoreSeedBusiness()
		{
			_gameScoreSeedRepository = new GameScoreSeedRepository();	
		}

		public async Task<List<GameApiPage>> GetGamesAsyncData()
		{
			var url = "https://api.rawg.io/api/games?page=1";
			var gamePagesApiList = new List<GameApiPage>();
			var count = 1;

			using (var client = new HttpClient())
			{
				while (!string.IsNullOrEmpty(url) && count <= 100)
				{
					var content = await client.GetStringAsync(url);
					var gamePageApi = JsonConvert.DeserializeObject<GameApiPage>(content);

					gamePagesApiList.Add(gamePageApi);
					url = gamePageApi.next;

					count++;
					Console.WriteLine(gamePageApi.next);
				}
			}

			return gamePagesApiList;
		}

		public void SeedApplicationDatabase(List<GameApiPage> gameApiPagesList)
		{
			foreach (var gameApiPage in gameApiPagesList)
			{
				CreateBulkData(gameApiPage);
			}

			_gameScoreSeedRepository.AddGames(m_gameList);
			_gameScoreSeedRepository.AddPlatforms(m_platformList);
			_gameScoreSeedRepository.AddGenres(m_genreList);
			_gameScoreSeedRepository.AddPlatformGames(m_platformGameList);
			_gameScoreSeedRepository.AddGenreGames(m_genreGameList);
		}

		private void CreateBulkData(GameApiPage gameApiPage)
		{
			foreach (var gameApi in gameApiPage.results)
			{
				var game = UpdateGamesList(gameApi);

				UpdatePlatformsList(gameApi.platforms, game);
				UpdateGenresList(gameApi.genres, game);
			}
		}

		private Game UpdateGamesList(GameApi gameApi)
		{
			var game = MapTools.MapApiGameToApplicationModel(gameApi);
			m_gameList.Add(game);

			return game;
		}

		private void UpdatePlatformsList(List<PlatformsApi> platforms, Game game)
		{
			var mappedPlatformList = MapTools.MapApiPlatformsToApplicationModels(platforms);
			foreach (var mappedPlatform in mappedPlatformList)
			{
				if (!m_platformList.Any(p => p.OriginalId == mappedPlatform.OriginalId))
					m_platformList.Add(mappedPlatform);

				m_platformGameList.Add(new PlatformGame {
					Game = game,
					GameId = game.Id,
					Platform = m_platformList.Where(p => p.OriginalId == mappedPlatform.OriginalId).First(),
					PlatformId = m_platformList.Where(p => p.OriginalId == mappedPlatform.OriginalId).First().Id
				});
			}
		}

		private void UpdateGenresList(List<GenreApi> genres, Game game)
		{
			var mappedGenreList = MapTools.MapApiGenresToApplicationModels(genres);
			foreach (var mappedGenre in mappedGenreList)
			{
				if (!m_genreList.Any(p => p.OriginalId == mappedGenre.OriginalId))
					m_genreList.Add(mappedGenre);

				m_genreGameList.Add(new GenreGame {
					Game = game,
					GameId = game.Id,
					Genre = m_genreList.Where(g => g.OriginalId == mappedGenre.OriginalId).First(),
					GenreId = m_genreList.Where(g => g.OriginalId == mappedGenre.OriginalId).First().Id
				});
			}
		}
	}
}
