using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.RL.Interfaces
{
	public interface IAccountRepository : IBaseRepository<User>
	{
		public User GetUserByUsername(string username);
	}
}
