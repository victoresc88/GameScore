using System;
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

		public GameScoreSeedBusiness()
		{
			_gameScoreSeedRepository = new GameScoreSeedRepository();	
		}

		public async Task<List<GameApiPage>> GetGamesAsyncData()
		{
			var url = "https://api.rawg.io/api/games?page=1";
			var gamePagesApiList = new List<GameApiPage>();
			var count = 1;

			while (!string.IsNullOrEmpty(url) && count <= 1)
			{
				var content = await new HttpClient().GetStringAsync(url);
				var gamePageApi = JsonConvert.DeserializeObject<GameApiPage>(content);

				gamePagesApiList.Add(gamePageApi);
				url = gamePageApi.next;

				count++;
				Console.WriteLine(gamePageApi.next);
			}

			return gamePagesApiList;
		}

		public void SeedApplicationDatabase(List<GameApiPage> gameApiPagesList)
		{
			foreach (var gameApiPage in gameApiPagesList)
			{
				foreach (var gameApi in gameApiPage.results)
				{
					var game = MapTools.MapApiGameToApplicationModel(gameApi);
					_gameScoreSeedRepository.AddGame(game);

					var platformList = MapTools.MapApiPlatformsToApplicationModels(gameApi.platforms);
					_gameScoreSeedRepository.AddPlatformGame(platformList, game);

					var genreList = MapTools.MapApiGenresToApplicationModels(gameApi.genres);
					_gameScoreSeedRepository.AddGenreGame(genreList, game);
				}
			}
		}
	}
}
