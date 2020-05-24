using GameScore.BL.Interfaces;
using GameScore.Entities;
using System.Linq;
using GameScore.RL.Interfaces;
using System;

namespace GameScore.BL
{
	public class ScoreBusiness : IScoreBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public ScoreBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public void UpdateScoreByGameId(int id)
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
			}

			_wrapperRepository.Game.Update(game);
			_wrapperRepository.Save();
		}

		public Score GetScoreByGameId(int id)
		{
			var score = _wrapperRepository.Score.GetScoreByGameId(id);

			if (score != null)
			{
				score.Graphics = (float)Math.Round(score.Graphics, 1);
				score.Gameplay = (float)Math.Round(score.Gameplay, 1);
				score.Sound = (float)Math.Round(score.Sound, 1);
				score.Narrative = (float)Math.Round(score.Narrative, 1);
				score.Total = (float)Math.Round(score.Total, 1);
			}
			
			return score;
		}
	}
}
