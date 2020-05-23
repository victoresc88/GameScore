using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameScore.RL
{
	public class GameRepository : BaseRepository<Game>, IGameRepository
	{
		public GameRepository(GameScoreDbContext context) : base(context)
		{
		}

		public Game GetGameById(int id)
		{
			return _context.Games
				.Where(g => g.Id == id)
				.Include(g => g.Score)
				.FirstOrDefault();
		}

		public IEnumerable<Game> GetListOfGames()
		{
			return _context.Games
				.OrderByDescending(g => g.ReleaseDate);
		}
	}
}
