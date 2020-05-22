using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.RL
{
	public class GameRepository : BaseRepository<Game>, IGameRepository
	{
		public GameRepository(GameScoreDbContext context) : base(context)
		{
		}
	}
}
