using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.RL.Interfaces
{
	public interface IGameRepository : IBaseRepository<Game>
	{
		public IEnumerable<Game> GetGames();
		public Game GetGameById(int id);
		public IEnumerable<Game> GetGamesByGenreId(int id);
		public IEnumerable<Game> GetGamesByPlatformId(int id);
	}
}
