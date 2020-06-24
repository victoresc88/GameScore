using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
	public class GameController : Controller
	{
		public const int ITEMS_PER_PAGE = 20;

		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public GameController(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		[AllowAnonymous]
		public IActionResult Details(int id)
		{
			var game = _wrapperBusiness.Game.GetGameById(id);
			var gameDetails = _mapper.Map<GameDetailsViewModel>(game);

			return View(gameDetails);
		}

		[AllowAnonymous]
		public IActionResult Search(string keyword)
		{
			_wrapperBusiness.Cache.SetSearchedGames(keyword);

			var pageNumber = 0;
			var listOfGames = GetListOfGamesForPage(pageNumber);

			return View("_SearchList", listOfGames);
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

			var gamesByIndexInCache = _wrapperBusiness.Cache.GetGamesByIndex("_SearchListEntry");
			var gamesByIndex = _mapper.Map<Dictionary<int, GameViewModel>>(gamesByIndexInCache);
			var listOfGames = gamesByIndex
				.Where(x => x.Key > indexFrom && x.Key <= indexTo)
				.ToDictionary(x => x.Key, x => x.Value).Values
				.ToList();

			return listOfGames;
		}
	}
}