using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
	public class ScoreController : Controller
	{
		private readonly IScoreBusiness _scoreBusiness;
		private readonly IMapper _mapper;

		public ScoreController(IScoreBusiness scoreBusiness, IMapper mapper)
		{
			_scoreBusiness = scoreBusiness;
			_mapper = mapper;
		}

		[HttpPost]
		[AllowAnonymous]
		public ViewComponentResult Rate([FromBody] RateViewModel rateViewModel)
		{
			var rate = _scoreBusiness.SetUserRates(
				_mapper.Map<Rate>(rateViewModel), 
				HttpContext.User.Identity.Name);
			_scoreBusiness.UpdateGameScore(rate.GameId);

			return ViewComponent("Rate");
		}
	}
}