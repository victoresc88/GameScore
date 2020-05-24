using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameScore.UI.ViewComponents
{
	public class RateViewComponent : ViewComponent
	{
		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public RateViewComponent(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		public IViewComponentResult Invoke(int id)
		{
			var username = HttpContext.User.Identity.Name;
			var rate = _wrapperBusiness.Rate.GetRateOfUserByGameId(id, username);

			var rateViewModel = _mapper.Map<RateViewModel>(rate) ?? new RateViewModel();
			rateViewModel.GameId = id.ToString();
			rateViewModel.Grades = CreateGradeSelectListItem();
			
			return View("Rate", rateViewModel);
		}

		private List<SelectListItem> CreateGradeSelectListItem()
		{
			return new List<SelectListItem>() {
				new SelectListItem { Text = "Not Rated", Value = "" },
				new SelectListItem { Text = "Horrible", Value = "1" },
				new SelectListItem { Text = "Very Bad", Value = "2" },
				new SelectListItem { Text = "Bad", Value = "3" },
				new SelectListItem { Text = "Not Good", Value = "4" },
				new SelectListItem { Text = "Meh", Value = "5" },
				new SelectListItem { Text = "Interesting", Value = "6" },
				new SelectListItem { Text = "Good", Value = "7" },
				new SelectListItem { Text = "Very Good", Value = "8" },
				new SelectListItem { Text = "Excellent", Value = "9" },
				new SelectListItem { Text = "Awesome", Value = "10" }
			};
		}
	}
}
