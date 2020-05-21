using GameScore.Entities;
using System.Security.Claims;

namespace GameScore.BL.Interfaces
{
	public interface IAccountBusiness
	{
		User CreateNewUser(string username, string password);
		User GetUserByUsernameAndPassword(string username, string password);
		ClaimsPrincipal CreateClaimsPrincipal(User user, string scheme);
	}
}
