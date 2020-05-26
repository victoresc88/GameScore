using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameScore.UI.Controllers
{
	public class GameController : Controller
	{
		public const int ITEMS_PER_PAGE = 20;

		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMemoryCache _cache;
		private readonly IMapper _mapper;

		public GameController(IWrapperBusiness wrapperBusiness, IMapper mapper, IMemoryCache cache)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
			_cache = cache;
		}

		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var game = _wrapperBusiness.Game.GetGameById(id);
			var gameDetails = _mapper.Map<GameDetailsViewModel>(game);

			return View(gameDetails);
		}

		[AllowAnonymous]
		public IActionResult Search(string name)
		{
			SetSearchItemsInCache(name);

			var pageNumber = 0;
			var listOfGames = GetListOfGamesForPage(pageNumber);

			return View("SearchList", listOfGames);
		}

		[HttpGet]
		[AllowAnonymous]
		public PartialViewResult RenderSearchListPage(int? pageNumber)
		{
			pageNumber = pageNumber ?? 0;
			var listOfGames = GetListOfGamesForPage(pageNumber.Value);

			return PartialView("_GamesPage", listOfGames);
		}

		private List<GameViewModel> GetListOfGamesForPage(int pageNumber)
		{
			var indexFrom = pageNumber * ITEMS_PER_PAGE;
			var indexTo = indexFrom + ITEMS_PER_PAGE;

			var gamesByIndexInCache = _wrapperBusiness.Game.GetGameByIndexFromCache(_cache, "_SearchListEntry");
			var gamesByIndex = _mapper.Map<Dictionary<int, GameViewModel>>(gamesByIndexInCache);
			var listOfGames = gamesByIndex
				.Where(x => x.Key > indexFrom && x.Key <= indexTo)
				.ToDictionary(x => x.Key, x => x.Value).Values
				.ToList();

			return listOfGames;
		}

		private void SetSearchItemsInCache(string name)
		{
			var gamesByIndexInCache = _wrapperBusiness.Game.GetGameByIndexFromCache(_cache, "_GamesEntry").Values.ToList();
			var listOfSearchedGames = gamesByIndexInCache
				.Where(x => x.Name
					.ToLower()
					.Contains(name.ToLower()))
				.ToList();

			var gameIndex = 1;
			var searchedGamestByIndex = listOfSearchedGames.ToDictionary(x => gameIndex++, x => x);

			_cache.Set("_SearchListEntry", searchedGamestByIndex, new MemoryCacheEntryOptions());
		}
	}
}