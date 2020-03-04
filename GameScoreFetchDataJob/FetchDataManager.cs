using AutoMapper;
using GameScoreFetchDataJob.Mapping;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.OriginalModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	public class FetchDataManager
	{
		public async Task<List<OriginalGamePage>> GetGamesAsyncData()
		{
			var client = new HttpClient();
			var baseUrl = "https://api.rawg.io/api/games?page=1";
			var originalGameDataList = new List<OriginalGamePage>();
			var count = 0;

			while (!string.IsNullOrEmpty(baseUrl) && count < 5)
			{
				var content = await client.GetStringAsync(baseUrl);
				var originalGamePage = JsonConvert.DeserializeObject<OriginalGamePage>(content);

				originalGameDataList.Add(originalGamePage);
				baseUrl = originalGamePage.next;

				Console.WriteLine(originalGamePage.next);

				count++;
			}

			return originalGameDataList;
		}

		public void MapOriginalGameDataToDbContextModels(List<OriginalGamePage> originalGamePageData)
		{
			var gameScoreSeedContextFactory = new GameScoreSeedContextFactory();
			var context = gameScoreSeedContextFactory.CreateDbContext();
			
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<PlatformProfile>();
			});
			var mapper = config.CreateMapper();

			foreach (var originalGamePage in originalGamePageData)
			{
				foreach (var originalGame in originalGamePage.results)
				{
					var game = mapper.Map<OriginalGame, Game>(originalGame);
					context.Add<Game>(game);
				}
			}

			try
			{
				context.SaveChanges();
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
