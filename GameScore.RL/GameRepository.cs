using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;

namespace GameScore.RL
{
	public class GameRepository : BaseRepository<Game>, IGameRepository
	{
		public GameRepository(GameScoreDbContext context) : base(context)
		{
		}
	}
}
