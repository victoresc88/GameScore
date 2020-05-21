using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.ViewComponents
{
	public class ScoreViewComponent : ViewComponent
	{
		private readonly IScoreBusiness _scoreBusiness;

		public ScoreViewComponent(IScoreBusiness scoreBusiness)
		{
			_scoreBusiness = scoreBusiness;
		}

		public IViewComponentResult Invoke()
		{


			return View("Score");
		}
	}
}
