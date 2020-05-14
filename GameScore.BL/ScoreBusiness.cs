using GameScore.BL.Interfaces;
using GameScore.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL
{
	public class ScoreBusiness : IScoreBusiness
	{
		private readonly GameScoreDbContext _context;

		public ScoreBusiness()
		{
			_context = new GameScoreDbContextFactory().CreateDbContext();
		}
	}
}
