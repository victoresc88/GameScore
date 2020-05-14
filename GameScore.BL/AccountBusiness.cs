using GameScore.BL.Interfaces;
using GameScore.DAL;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace GameScore.BL
{
	public class AccountBusiness : IAccountBusiness
	{
		private readonly GameScoreDbContext _context;

		public AccountBusiness()
		{
			_context = new GameScoreDbContextFactory().CreateDbContext();
		}

		public User GetUserByUsernameAndPassword(string username, string password)
		{
			var user = _context.Users.SingleOrDefault(u => u.Name == username &&
				 u.Password == password.Hash());

			return user;
		}

		public User CreateNewUser(string username, string password)
		{
			_context.Users.Add(new User
			{
				Name = username,
				Password = password.Hash()
			});
			_context.SaveChanges();

			return _context.Users.SingleOrDefault(u => u.Name == username &&
				 u.Password == password.Hash());
		}

		public ClaimsPrincipal CreateClaimsPrincipal(User user, string scheme)
		{
			var claims = new List<Claim>
				{
					 new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
					 new Claim(ClaimTypes.Name, user.Name)
				};

			var identity = new ClaimsIdentity(claims, scheme);
			var principal = new ClaimsPrincipal(identity);

			return principal;
		}
	}
}
