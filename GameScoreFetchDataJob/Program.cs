﻿using System;
using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var fetchDataManager = new FetchDataManager();
			var games = await fetchDataManager.GetGamesAsync();
		}
	}
}
