using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.RL.Interfaces
{
	public interface IRateRepository : IBaseRepository<Rate>
	{
		public Rate GetRateOfUserByGameId(int id, string username);
		public IEnumerable<Rate> GetListOfRatesByGameId(int id);
	}
}
