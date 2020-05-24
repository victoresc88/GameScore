using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.ViewComponents
{
	public class ScoreViewComponent : ViewComponent
	{
		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public ScoreViewComponent(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke(int id)
		{
			var score = _wrapperBusiness.Score.GetScoreByGameId(id);
			var scoreViewModel = _mapper.Map<ScoreViewModel>(score) ?? new ScoreViewModel();
			scoreViewModel.NumberOfRates = _wrapperBusiness.Rate.GetNumberOfRatesByGameId(id);
			scoreViewModel.GraphicsProgress = CalculateProgressBar(scoreViewModel.Graphics);
			scoreViewModel.GameplayProgress = CalculateProgressBar(scoreViewModel.Gameplay);
			scoreViewModel.SoundProgress = CalculateProgressBar(scoreViewModel.Sound);
			scoreViewModel.NarrativeProgress = CalculateProgressBar(scoreViewModel.Narrative);

			return View("Score", scoreViewModel);
		}

		private string CalculateProgressBar(float grade)
		{
			var progressBarClassName = string.Empty;

			if (grade >= 8.0)
				progressBarClassName = "bg-success";
			if (grade >= 6.0 && grade < 8.0)
				progressBarClassName = "bg-info";
			if (grade >= 4.0 && grade < 6.0)
				progressBarClassName = "bg-warning";
			if (grade >= 0 && grade < 4.0)
				progressBarClassName = "bg-danger";

			return progressBarClassName;
		}
	}
}
