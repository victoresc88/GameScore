using GameScore.RL.Interfaces;
using GameScore.Entities;
using GameScore.DAL;
using System.Linq;

namespace GameScore.RL
{
	public class ScoreRepository : BaseRepository<Score>, IScoreRepository
	{
		public ScoreRepository(GameScoreDbContext context) : base(context)
		{
		}

		public Score GetScoreByGameId(int id)
		{
			return _context.Scores
				.Where(s => s.GameId == id)
				.FirstOrDefault();
		}
	}
}
