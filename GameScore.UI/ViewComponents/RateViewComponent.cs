using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.ViewComponents
{
	public class RateViewComponent : ViewComponent
	{
		private readonly IWrapperBusiness _wrapperBusiness;

		public RateViewComponent(IWrapperBusiness wrapperBusiness)
		{
			_wrapperBusiness = wrapperBusiness;
		}

		public IViewComponentResult Invoke(int id)
		{
			return View("Rate", id);
		}
	}
}
