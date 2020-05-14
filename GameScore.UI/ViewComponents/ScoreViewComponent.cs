using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
