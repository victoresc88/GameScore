using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GameScore.UI.Controllers
{
    public class GameController : Controller
    {
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

        [HttpGet]
        public PartialViewResult GetGameFromMemoryCache(string name)
        {
            var listOfCache = (_cache.Get("_GamesEntry") as Dictionary<int, GameViewModel>).Values.ToList();
            var listOfGames = listOfCache.Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

            return PartialView("_GamesPage", listOfGames);
        }
    }
}