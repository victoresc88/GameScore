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
			SetListOfGamesInCache();

			var numberOfPage = 0;
			var gamesByIndexInCache = _wrapperBusiness.Game.GetGameByIndexFromCache(_cache, "_GamesEntry");
			var gamesByIndex = _wrapperBusiness.Game.GetGamesByIndexForPage(gamesByIndexInCache, numberOfPage);

			return View("Index", _mapper.Map<IEnumerable<GameViewModel>>(gamesByIndex.Values.ToList()));
		}

		[HttpGet]
		public IActionResult RenderGamesPage(int? pageNumber)
		{
			var numberOfPage = pageNumber ?? 0;
			var gamesByIndexInCache = _wrapperBusiness.Game.GetGameByIndexFromCache(_cache, "_GamesEntry");
			var gamesByIndex = _wrapperBusiness.Game.GetGamesByIndexForPage(gamesByIndexInCache, numberOfPage);

			return PartialView("_GamesPage", _mapper.Map<IEnumerable<GameViewModel>>(gamesByIndex.Values.ToList()));
		}

		private void SetListOfGamesInCache()
		{
			var index = 1;
			var listOfGames = _wrapperBusiness.Game.GetListOfGames();
			var gamesByIndex = listOfGames
				.ToDictionary(g => index++, g => g);

			_cache.Set(
				"_GamesEntry", 
				gamesByIndex, 
				new MemoryCacheEntryOptions()
					.SetSlidingExpiration(TimeSpan.FromMinutes(60))
			);
		}
	}
}
