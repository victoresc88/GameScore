using GameScore.BL.Interfaces;
using GameScore.Entities;
using System.Linq;
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
			var currentRateOfUser = _wrapperRepository.Rate.GetRateOfUserByGameId(rate.GameId, username);
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

			_wrapperRepository.Save();

			return rate;
		}

		public void UpdateGameScore(int id)
		{
			var game = _wrapperRepository.Game.GetGameById(id);
			var listOfRates = _wrapperRepository.Rate.GetListOfRatesByGameId(id);

			if (listOfRates != null)
			{
				game.Score = new Score {
					Graphics = (float)listOfRates.Average(item => item.Graphics),
					Gameplay = (float)listOfRates.Average(item => item.Gameplay),
					Sound = (float)listOfRates.Average(item => item.Sound),
					Narrative = (float)listOfRates.Average(item => item.Narrative),
					Total = listOfRates.Average(item => item.Total)
				};

				_wrapperRepository.Game.Update(game);
			}

			_wrapperRepository.Save();
		}
	}
}
