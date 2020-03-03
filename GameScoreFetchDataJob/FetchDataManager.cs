using GameScoreFetchDataJob.Models;
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
		public async Task<List<GameOrigin>> GetGamesAsync()
		{
			var gameOriginList = await GetGamesData();

			return gameOriginList;
		}

		private async Task<List<GameOrigin>> GetGamesData()
		{
			var client = new HttpClient();
			var baseUrl = "https://api.rawg.io/api/games?page=1";
			var gameOriginList = new List<GameOrigin>();

			while (!string.IsNullOrEmpty(baseUrl))
			{
				var content = await client.GetStringAsync(baseUrl);

				var gameOrigin = JsonConvert.DeserializeObject<GameOrigin>(content);
				baseUrl = gameOrigin.next;

				gameOriginList.Add(gameOrigin);

				Console.WriteLine(gameOrigin.next);
			}

			return gameOriginList;
		}
	}
}
