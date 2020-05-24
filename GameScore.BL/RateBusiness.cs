using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Linq;

namespace GameScore.BL
{
	public class RateBusiness : IRateBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public RateBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public Rate Create(Rate rate, User user)
		{
			rate.UserId = user.Id;
			rate.User = user;
			rate.Total = CalculateAverageOfCurrentRate(rate);
			
			_wrapperRepository.Rate.Create(rate);
			_wrapperRepository.Save();

			return rate;
		}

		public Rate Update(Rate currentRate, Rate sourceRate)
		{
			currentRate.Graphics = sourceRate.Graphics;
			currentRate.Gameplay = sourceRate.Gameplay;
			currentRate.Sound = sourceRate.Sound;
			currentRate.Narrative = sourceRate.Narrative;
			currentRate.Total = CalculateAverageOfCurrentRate(sourceRate);

			_wrapperRepository.Rate.Update(currentRate);
			_wrapperRepository.Save();

			return currentRate;
		}

		public Rate GetRateOfUserByGameId(int id, string username)
		{
			return _wrapperRepository.Rate.GetRateOfUserByGameId(id, username);
		}

		public int GetNumberOfRatesByGameId(int id)
		{
			return _wrapperRepository.Rate.GetNumberOfRatesByGameId(id);
		}

		private float CalculateAverageOfCurrentRate(Rate rate)
		{
			var arrayOfRates = new float[] { rate.Graphics, rate.Gameplay, rate.Sound, rate.Narrative };
			
			return arrayOfRates.Average();
		}
	}
}
