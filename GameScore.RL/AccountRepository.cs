﻿using GameScore.RL.Interfaces;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameScore.DAL;

namespace GameScore.RL
{
	public class AccountRepository : BaseRepository<User>, IAccountRepository
	{
		public AccountRepository(GameScoreDbContext context) : base(context)
		{
		}

		public User GetUserByUsername(string username)
		{
			return _context.Users
				.Where(u => u.Name == username)
				.FirstOrDefault();
		}

	}
}