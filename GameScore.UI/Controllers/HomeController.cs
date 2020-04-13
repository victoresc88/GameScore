using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameScore.UI.Models;
using AutoMapper;
using GameScore.UI.ViewModels;
using GameScore.BL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace GameScore.UI.Controllers
{
    public class HomeController : Controller
    {
        public const int RECORDS_PER_PAGE = 5;

        private readonly IHomeBusiness _homeBusiness;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _cache;

        public HomeController(IMapper mapper, IHomeBusiness homeBusiness, IMemoryCache cache)
        {
            _mapper = mapper;
            _homeBusiness = homeBusiness;
            _cache = cache;

            ViewBag.RecordsPerPage = RECORDS_PER_PAGE;
        }

        public IActionResult Index(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;

            SetInfiniteScrollingCacheData();
            ViewBag.Games = GetRecordsForPage(pageNum.Value);
            
            return View("Index");
        }

        public IActionResult RenderGamesPage(int? pageNum)
        {
            pageNum = pageNum ?? 0;
            ViewBag.IsEndOfRecords = false;

            var games = GetRecordsForPage(pageNum.Value);

            return PartialView("_GamesPage", games);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public Dictionary<int, GameViewModel> GetRecordsForPage(int pageNum)
        {
            Dictionary<int, GameViewModel> games = (_cache.Get("_GamesEntry") as Dictionary<int, GameViewModel>);

            int from = (pageNum * RECORDS_PER_PAGE);
            int to = from + RECORDS_PER_PAGE;

            return games
                .Where(x => x.Key > from && x.Key <= to)
                .OrderBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private void SetInfiniteScrollingCacheData()
        {
            int custIndex = 1;

            var gameModelList = _homeBusiness.GetAllGames();
            var gameViewModelList = _mapper.Map<IEnumerable<GameViewModel>>(gameModelList);
            var gameDictionaryEntry = gameViewModelList.ToDictionary(g => custIndex++, g => g);         

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(120));

            _cache.Set("_GamesEntry", gameDictionaryEntry, cacheEntryOptions);
        }
    }
}
