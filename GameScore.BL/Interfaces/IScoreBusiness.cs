using GameScore.Entities;

namespace GameScore.BL.Interfaces
{
	public interface IScoreBusiness
	{
		public Rate SetUserRates(Rate rate, string userName);
		public void UpdateGameScore(int gameId);
	}
}
