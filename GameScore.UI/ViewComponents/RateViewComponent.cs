using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.UI.ViewComponents
{
	public class RateViewComponent : ViewComponent
	{
		private readonly IScoreBusiness _scoreBusiness;

		public RateViewComponent(IScoreBusiness scoreBusiness)
		{
			_scoreBusiness = scoreBusiness;
		}

		public IViewComponentResult Invoke()
		{
			return View("Rate");
		}
	}
}
