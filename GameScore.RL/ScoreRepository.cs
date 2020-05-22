using GameScore.RL.Interfaces;
using GameScore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
