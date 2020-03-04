using AutoMapper;
using GameScoreFetchDataJob.Mapping;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.RawgApiModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	public class FetchDataManager
	{
		public async Task<List<GameApiPage>> GetGamesAsyncData()
		{
			var url = "https://api.rawg.io/api/games?page=1";
			var gamePagesApiList = new List<GameApiPage>();
			var count = 0;

			while (!string.IsNullOrEmpty(url) && count < 5)
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
			
			var context = new GameScoreSeedContextFactory().CreateDbContext();
			try
			{
				context.Database.OpenConnection();
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games ON");
				context.Games.AddRange(gameList);
				context.SaveChanges();
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games OFF");
			}
			finally
			{
				context.Database.CloseConnection();
			}
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
