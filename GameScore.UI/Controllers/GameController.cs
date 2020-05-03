using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameScore.UI.Controllers
{
    public class GameController : Controller
    {
        public const int ITEMS_PER_PAGE = 20;

        private readonly IGameBusiness _gameBusiness;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public GameController(IGameBusiness gameBusiness, IMapper mapper, IMemoryCache cache)
        {
            _gameBusiness = gameBusiness;
            _mapper = mapper;
            _cache = cache;
        }

        public IActionResult Details(int id)
        {
            var game = _gameBusiness.GetGame(id);
            var gameDetails = _mapper.Map<GameDetailsViewModel>(game);

            return View(gameDetails);
        }

        public IActionResult Search(string name)
        {
            SetSearchItemsInCache(name);

            var pageNumber = 0;
            var gamesByIndex = GetItemsForPage(pageNumber);

            return View("SearchList", gamesByIndex.Values.ToList());
        }

        [HttpGet]
        public PartialViewResult RenderSearchListPage(int? pageNumber)
        {
            pageNumber = pageNumber ?? 0;
            var gamesByIndex = GetItemsForPage(pageNumber.Value);

            return PartialView("_GamesPage", gamesByIndex.Values.ToList());
        }

        private Dictionary<int, GameViewModel> GetItemsForPage(int pageNumber)
        {
            var gamesByIndex = _cache.Get("_SearchListEntry") as Dictionary<int, GameViewModel>;

            var indexFrom = pageNumber * ITEMS_PER_PAGE;
            var indexTo = indexFrom + ITEMS_PER_PAGE;

            return gamesByIndex
                .Where(x => x.Key > indexFrom && x.Key <= indexTo)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private void SetSearchItemsInCache(string name)
        {
            var listOfCache = (_cache.Get("_GamesEntry") as Dictionary<int, GameViewModel>).Values.ToList();
            var listOfGames = listOfCache.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

            var gameIndex = 1;
            var searchedGamestByIndex = listOfGames.ToDictionary(x => gameIndex++, x => x);

            _cache.Set("_SearchListEntry", searchedGamestByIndex, new MemoryCacheEntryOptions());
        }
    }
}