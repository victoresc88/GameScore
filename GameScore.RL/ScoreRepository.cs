using GameScore.RL.Interfaces;
using GameScore.Entities;
using GameScore.DAL;

namespace GameScore.RL
{
	public class ScoreRepository : BaseRepository<Score>, IScoreRepository
	{
		public ScoreRepository(GameScoreDbContext context) : base(context)
		{
		}
	}
}
