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

		public IEnumerable<Game> GetGames()
		{
			return _context.Games
				.OrderByDescending(g => g.ReleaseDate);
		}

		public Game GetGameById(int id)
		{
			return _context.Games
				.Where(g => g.Id == id)
				.Include(g => g.Score)
				.FirstOrDefault();
		}

        public IEnumerable<Game> GetGamesByGenreId(int id)
        {
			return _context.GenreGames
				.Where(g => g.GenreId == id)
				.Include(g => g.Game)
				.Select(g => g.Game)
				.ToList();
		}

		public IEnumerable<Game> GetGamesByPlatformId(int id)
        {
			return _context.PlatformGames
				.Where(g => g.PlatformId == id)
				.Include(g => g.Game)
				.Select(g => g.Game)
				.ToList();
		}

	}
}
