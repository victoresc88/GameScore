﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GameScore.UI.ViewModels;
using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace GameScore.UI.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
		public const int ITEMS_PER_PAGE = 20;

		private readonly IWrapperBusiness _wrapperBusiness;
		private readonly IMapper _mapper;

		public HomeController(IWrapperBusiness wrapperBusiness, IMapper mapper)
		{
			_wrapperBusiness = wrapperBusiness;
			_mapper = mapper;
		}

		public IActionResult Index()
		{
			var listOfGames = _wrapperBusiness.Game.GetGames();
			_wrapperBusiness.Cache.SetListOfGames(listOfGames);

			var numberOfPage = 0;
			var gamesByIndexInCache = _wrapperBusiness.Cache.GetGamesByIndex("_GamesEntry");
			var gamesByIndex = _wrapperBusiness.Game.GetGamesByIndexForPage(gamesByIndexInCache, numberOfPage);

			return View("Index", _mapper.Map<IEnumerable<GameViewModel>>(gamesByIndex.Values.ToList()));
		}

		[HttpGet]
		public IActionResult RenderGamesPage(int? pageNumber)
		{
			var numberOfPage = pageNumber ?? 0;
			var gamesByIndexInCache = _wrapperBusiness.Cache.GetGamesByIndex("_GamesEntry");
			var gamesByIndex = _wrapperBusiness.Game.GetGamesByIndexForPage(gamesByIndexInCache, numberOfPage);

			return PartialView("_GamesPage", _mapper.Map<IEnumerable<GameViewModel>>(gamesByIndex.Values.ToList()));
		}
	}
}
