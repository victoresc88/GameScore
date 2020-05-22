using GameScore.Entities;

namespace GameScore.RL.Interfaces
{
	public interface IRateRepository : IBaseRepository<Rate>
	{
		public Rate GetCurrentRateOfUserByGame(int gameId, string username);
	}
}
