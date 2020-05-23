using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.ViewComponents
{
	public class ScoreViewComponent : ViewComponent
	{
		private readonly IWrapperBusiness _wrapperBusiness;

		public ScoreViewComponent(IWrapperBusiness wrapperBusiness)
		{
			_wrapperBusiness = wrapperBusiness;
		}

		public IViewComponentResult Invoke()
		{
			return View("Score");
		}
	}
}
