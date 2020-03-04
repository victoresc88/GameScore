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
			var client = new HttpClient();
			var baseUrl = "https://api.rawg.io/api/games?page=1";
			var GameApiDataList = new List<GameApiPage>();
			var count = 0;

			while (!string.IsNullOrEmpty(baseUrl) && count < 5)
			{
				var content = await client.GetStringAsync(baseUrl);
				var GameApiPage = JsonConvert.DeserializeObject<GameApiPage>(content);

				GameApiDataList.Add(GameApiPage);
				baseUrl = GameApiPage.next;

				Console.WriteLine(GameApiPage.next);

				count++;
			}

			return GameApiDataList;
		}

		public void MapGameApiDataToDbContextModels(List<GameApiPage> GameApiPageData)
		{
			var gameScoreSeedContextFactory = new GameScoreSeedContextFactory();
			var context = gameScoreSeedContextFactory.CreateDbContext();
			
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<PlatformProfile>();
			});
			var mapper = config.CreateMapper();

			foreach (var GameApiPage in GameApiPageData)
			{
				foreach (var GameApi in GameApiPage.results)
				{
					var game = mapper.Map<GameApi, Game>(GameApi);
					context.Add<Game>(game);
				}
			}

			context.Database.OpenConnection();
			try
			{
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games ON");
				context.SaveChanges();
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games OFF");
			}
			finally
			{
				context.Database.CloseConnection();
			}
		}
	}
}
