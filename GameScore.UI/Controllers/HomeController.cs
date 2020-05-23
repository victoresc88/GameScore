using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GameScore.UI.ViewModels;
using GameScore.BL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Authorization;

namespace GameScore.UI.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		public const int ITEMS_PER_PAGE = 20;

		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMemoryCache _cache;
		private readonly IMapper _mapper;

		public HomeController(IWrapperBusiness wrapperBusiness, IMapper mapper, IMemoryCache cache)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
			_cache = cache;
		}

		public IActionResult Index()
		{
			SetAllItemsInCache();

			var pageNumber = 0;
			var gamesByIndex = GetItemsForPage(pageNumber);

			return View("Index", gamesByIndex.Values.ToList());
		}

		[HttpGet]
		public IActionResult RenderGamesPage(int? pageNumber)
		{
			pageNumber = pageNumber ?? 0;
			var gamesByIndex = GetItemsForPage(pageNumber.Value);

			return PartialView("_GamesPage", gamesByIndex.Values.ToList());
		}

		private Dictionary<int, GameViewModel> GetItemsForPage(int pageNumber)
		{
			var gamesByIndex = _cache.Get("_GamesEntry") as Dictionary<int, GameViewModel>;

			var indexFrom = pageNumber * ITEMS_PER_PAGE;
			var indexTo = indexFrom + ITEMS_PER_PAGE;

			return gamesByIndex
				 .Where(x => x.Key > indexFrom && x.Key <= indexTo)
				 .ToDictionary(x => x.Key, x => x.Value);
		}

		private void SetAllItemsInCache()
		{
			var gameIndex = 1;
			var listOfGames = _wrapperBusiness.Game.GetListOfGames();
			var gamesByIndex = _mapper.Map<IEnumerable<GameViewModel>>(listOfGames)
											.ToDictionary(x => gameIndex++, x => x);

			_cache.Set("_GamesEntry", gamesByIndex, new MemoryCacheEntryOptions()
				 .SetSlidingExpiration(TimeSpan.FromMinutes(60)));
		}
	}
}
