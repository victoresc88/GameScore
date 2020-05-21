using GameScore.BL.Interfaces;
using GameScore.DAL;
using GameScore.Entities;
using System.Collections.Generic;
using System.Linq;

namespace GameScore.BL
{
	public class HomeBusiness : IHomeBusiness
	{
		private readonly GameScoreDbContext _context;

		public HomeBusiness()
		{
			_context = new GameScoreDbContextFactory().CreateDbContext();
		}

		public IEnumerable<Game> GetAllGames()
		{
			return _context.Games
				.OrderByDescending(g => g.ReleaseDate);
		}
	}
}
