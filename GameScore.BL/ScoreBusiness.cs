using GameScore.BL.Interfaces;
using GameScore.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using GameScore.RL;
using GameScore.RL.Interfaces;

namespace GameScore.BL
{
	public class ScoreBusiness : IScoreBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public ScoreBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public Rate SetUserRates(Rate rate, string username)
		{
			var currentRateOfUser = _wrapperRepository.Rate.GetCurrentRateOfUserByGame(rate.GameId, username);
			var user = _wrapperRepository.Account.GetUserByUsername(username);

			rate.UserId = user.Id;
			rate.User = user;
			rate.Total = (rate.Graphics + rate.Gameplay + rate.Sound + rate.Narrative) / 4;

			if (currentRateOfUser == null)
			{
				_wrapperRepository.Rate.Create(rate);
			}
			else
			{
				currentRateOfUser.Graphics = rate.Graphics;
				currentRateOfUser.Gameplay = rate.Gameplay;
				currentRateOfUser.Sound = rate.Sound;
				currentRateOfUser.Narrative = rate.Narrative;
				currentRateOfUser.Total = rate.Total;

				_wrapperRepository.Rate.Update(currentRateOfUser);
			}

			return rate;
		}

		public void UpdateGameScore(int gameId)
		{
			//var score = new Score();

			//var game = _context.Games
			//	.Where(g => g.Id == gameId)
			//	.Include(g => g.Score)
			//	.FirstOrDefault();
			
			//var listOfRates = _context.Rates
			//	.Where(r => r.GameId == gameId);

			//if (listOfRates != null)
			//{
			//	score.Graphics = (float)listOfRates.Average(item => item.Graphics);
			//	score.Gameplay = (float)listOfRates.Average(item => item.Gameplay);
			//	score.Sound = (float)listOfRates.Average(item => item.Sound);
			//	score.Narrative = (float)listOfRates.Average(item => item.Narrative);
			//	score.Total = listOfRates.Average(item => item.Total);

			//	game.Score = score;
			//}

			//_context.SaveChanges();
		}
	}
}
