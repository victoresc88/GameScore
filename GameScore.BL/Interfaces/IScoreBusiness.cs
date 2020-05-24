using GameScore.Entities;

namespace GameScore.BL.Interfaces
{
	public interface IScoreBusiness
	{
		public void UpdateScoreByGameId(int id);
		public Score GetScoreByGameId(int id);
	}
}
