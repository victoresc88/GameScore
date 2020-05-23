using GameScore.Entities;
using System.Security.Claims;

namespace GameScore.BL.Interfaces
{
	public interface IAccountBusiness
	{
		public User CreateNewUser(string username, string password);
		public User GetUserByUsername(string username);
		public User GetUserByUsernameAndPassword(string username, string password);
		public ClaimsPrincipal CreateClaimsPrincipal(User user, string scheme);
	}
}
