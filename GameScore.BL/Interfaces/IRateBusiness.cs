using GameScore.Entities;

namespace GameScore.BL.Interfaces
{
	public interface IRateBusiness
	{
		public Rate Update(Rate sourceRate, Rate currentRate);
		public Rate GetRateOfUserByGameId(int id, string username);
		public Rate Create(Rate rate, User user);
	}
}
