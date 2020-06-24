using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
	public interface IGameBusiness
	{
		public IEnumerable<Game> GetGames();
		public Game GetGameById(int id);
		public Dictionary<int, Game> GetGamesByIndexForPage(Dictionary<int, Game> gamesByIndex, int numberOfPage);
		public IEnumerable<Game> GetGamesByGenreId(int id);
		public IEnumerable<Game> GetGamesByPlatformId(int id);
    }
}
