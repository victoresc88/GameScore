using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
	public interface IGameBusiness
	{
		public Game GetGameById(int id);
		public IEnumerable<Game> GetListOfGames();
	}
}
