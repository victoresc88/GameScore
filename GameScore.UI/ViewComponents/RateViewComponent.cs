using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.ViewComponents
{
	public class RateViewComponent : ViewComponent
	{
		private readonly IScoreBusiness _scoreBusiness;

		public RateViewComponent(IScoreBusiness scoreBusiness)
		{
			_scoreBusiness = scoreBusiness;
		}

		public IViewComponentResult Invoke(int id)
		{
			return View("Rate", id);
		}
	}
}
