﻿using GameScore.RL.Interfaces;
using GameScore.Entities;
using System.Linq;
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

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			return _context.Users
				.SingleOrDefault(u => u.Name == username 
					&& u.Password == password);
		}
	}
}
