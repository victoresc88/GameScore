using GameScoreFetchDataJob.OriginalModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	public class FetchDataManager
	{
		public async Task<List<OriginalGameData>> GetGamesAsyncData()
		{
			var client = new HttpClient();
			var baseUrl = "https://api.rawg.io/api/games?page=1";
			var originalGameDataList = new List<OriginalGameData>();
			var count = 0;

			while (!string.IsNullOrEmpty(baseUrl) && count < 5)
			{
				var content = await client.GetStringAsync(baseUrl);
				var OriginalGameData = JsonConvert.DeserializeObject<OriginalGameData>(content);

				originalGameDataList.Add(OriginalGameData);
				baseUrl = OriginalGameData.next;

				Console.WriteLine(OriginalGameData.next);

				count++;
			}

			return originalGameDataList;
		}

		public void MapOriginalGameDataToDbContextModels(List<OriginalGameData> originalGameData)
		{
			var gameScoreSeedContextFactory = new GameScoreSeedContextFactory();
			var context = gameScoreSeedContextFactory.CreateDbContext();
			var games = context.Games;

			foreach (var game in games)
			{
				Console.WriteLine(game.Name);
			}
		}
	}
}
