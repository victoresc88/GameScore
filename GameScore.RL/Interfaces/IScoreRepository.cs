using GameScore.Entities;

namespace GameScore.RL.Interfaces
{
	public interface IScoreRepository : IBaseRepository<Score>
	{
		public Score GetScoreByGameId(int id);
	}
}
