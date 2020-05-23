using GameScore.Entities;

namespace GameScore.RL.Interfaces
{
	public interface IAccountRepository : IBaseRepository<User>
	{
		public User GetUserByUsername(string username);
		public User GetUserByUsernameAndPassword(string username, string password);
	}
}
