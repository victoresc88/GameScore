using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameScore.RL
{
	public class RateRepository : BaseRepository<Rate>, IRateRepository
	{
		public RateRepository(GameScoreDbContext context) : base(context)
		{
		}

		public Rate GetCurrentRateOfUserByGame(int gameId, string username)
		{
			return _context.Rates
				.Include(r => r.User)
				.Where(r => r.GameId == gameId
					&& r.User.Name == username)
				.FirstOrDefault();
		}
	}
}
