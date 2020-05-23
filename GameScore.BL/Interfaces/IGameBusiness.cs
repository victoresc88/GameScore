using GameScore.Entities;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
	public interface IGameBusiness
	{
		public Game GetGameById(int id);
		public IEnumerable<Game> GetListOfGames();
		public Dictionary<int, Game> GetListOfGamesForPage(IMemoryCache cache, int numberOfPage);
	}
}
