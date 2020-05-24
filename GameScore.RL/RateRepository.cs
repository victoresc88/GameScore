using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace GameScore.RL
{
	public class RateRepository : BaseRepository<Rate>, IRateRepository
	{
		public RateRepository(GameScoreDbContext context) : base(context)
		{
		}

		public Rate GetRateOfUserByGameId(int id, string username)
		{
			return _context.Rates
				.Include(r => r.User)
				.Where(r => r.GameId == id
					&& r.User.Name == username)
				.FirstOrDefault();
		}

		public IEnumerable<Rate> GetListOfRatesByGameId(int id)
		{
			return _context.Rates
				.Where(r => r.GameId == id);
		}

		public int GetNumberOfRatesByGameId(int id)
		{
			return _context.Rates
				.Where(r => r.GameId == id)
				.Count();
		}
	}
}
