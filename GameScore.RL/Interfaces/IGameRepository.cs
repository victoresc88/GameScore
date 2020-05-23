using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.RL.Interfaces
{
	public interface IGameRepository : IBaseRepository<Game>
	{
		public Game GetGameById(int id);
		public IEnumerable<Game> GetListOfGames();
	}
}
