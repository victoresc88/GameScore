using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.RL.Interfaces
{
	public interface IRateRepository : IBaseRepository<Rate>
	{
		public Rate GetCurrentRateOfUserByGame(int gameId, string username);
	}
}
