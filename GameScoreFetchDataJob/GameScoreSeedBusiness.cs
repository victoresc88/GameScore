using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.Mapping;
using GameScoreFetchDataJob.Repository;
using GameScoreFetchDataJob.ApiModels;

using AutoMapper;
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

			while (!string.IsNullOrEmpty(url) && count <= 2)
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

		public void SeedGameScoreDatabase(List<GameApiPage> gamePagesApiList)
		{
			
			var gameList = MapApiModelsToGameScoreModels(gamePagesApiList);

			_gameScoreSeedRepository.SeedDB(gameList);
		}

		private IEnumerable<Game> MapApiModelsToGameScoreModels(List<GameApiPage> gamePagesApiList)
		{
			var gameList = new List<Game>();
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<PlatformProfile>();
			});
			var mapper = config.CreateMapper();

			foreach (var gameApiPage in gamePagesApiList)
			{
				foreach (var gameApi in gameApiPage.results)
				{
					var game = mapper.Map<GameApi, Game>(gameApi);
					gameList.Add(game);
				}
			}

			return gameList;
		}
	}
}
