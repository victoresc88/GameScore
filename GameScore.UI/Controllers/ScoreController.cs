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
		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public ScoreController(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		[HttpPost]
		[AllowAnonymous]
		public ViewComponentResult Rate([FromBody] RateViewModel rateViewModel)
		{
			var rate = _wrapperBusiness.Score.SetUserRates(
				_mapper.Map<Rate>(rateViewModel), 
				HttpContext.User.Identity.Name);
			_wrapperBusiness.Score.UpdateGameScore(rate.GameId);

			return ViewComponent("Rate");
		}
	}
}