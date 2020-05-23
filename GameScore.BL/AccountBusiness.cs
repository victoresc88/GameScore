using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;
using System.Security.Claims;

namespace GameScore.BL
{
	public class AccountBusiness : IAccountBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public AccountBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public User GetUserByUsername(string username)
		{
			return _wrapperRepository.Account.GetUserByUsername(username);
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			var hashedPassword = password.Hash();
			var user = _wrapperRepository.Account.GetUserByUsernameAndPassword(username, hashedPassword);

			return user;
		}

		public User CreateNewUser(string username, string password)
		{
			var hashedPassword = password.Hash();

			_wrapperRepository.Account.Create(
				new User { 
					Name = username, 
					Password = hashedPassword 
				}
			);
			_wrapperRepository.Save();

			return _wrapperRepository.Account.GetUserByUsernameAndPassword(username, hashedPassword);
		}

		public ClaimsPrincipal CreateClaimsPrincipal(User user, string scheme)
		{
			var claims = new List<Claim> {
				new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new Claim(ClaimTypes.Name, user.Name)
			};

			var identity = new ClaimsIdentity(claims, scheme);
			var principal = new ClaimsPrincipal(identity);

			return principal;
		}
	}
}
