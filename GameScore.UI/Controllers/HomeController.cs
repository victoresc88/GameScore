using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GameScore.UI.ViewModels;
using GameScore.BL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GameScore.UI.Controllers
{
    public class HomeController : Controller
    {
        public const int ITEMS_PER_PAGE = 30;

        private readonly IHomeBusiness _homeBusiness;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public HomeController(IHomeBusiness homeBusiness, IMapper mapper, IMemoryCache cache)
        {
            _homeBusiness = homeBusiness;
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

            var listOfGames = _homeBusiness.GetAllGames();
            var gamesByIndex = _mapper.Map<IEnumerable<GameViewModel>>(listOfGames)
                                    .ToDictionary(x => gameIndex++, x => x);         

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(60));

            _cache.Set("_GamesEntry", gamesByIndex, cacheEntryOptions);
        }
    }
}
