using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
	public interface IHomeBusiness
	{
		public IEnumerable<Game> GetAllGames();
	}
}
