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
