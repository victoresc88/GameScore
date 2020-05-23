using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
	public class RateController : Controller
	{
		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public RateController(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		[HttpPost]
		[AllowAnonymous]
		public ViewComponentResult Submit([FromBody] RateViewModel rateViewModel)
		{
			var sourceRate = _mapper.Map<Rate>(rateViewModel);
			var username = HttpContext.User.Identity.Name;

			var user = _wrapperBusiness.Account.GetUserByUsername(username);
			var currentRate = _wrapperBusiness.Rate.GetRateOfUserByGameId(sourceRate.GameId, username);

			currentRate = (currentRate == null) ? 
				_wrapperBusiness.Rate.Create(sourceRate, user) : 
				_wrapperBusiness.Rate.Update(currentRate, sourceRate);	

			_wrapperBusiness.Score.UpdateGameScore(currentRate.GameId);

			return ViewComponent("Rate");
		}
	}
}