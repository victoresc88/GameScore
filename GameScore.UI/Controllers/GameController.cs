using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.UI.Controllers
{
    public class GameController : Controller
    {
        private readonly IGameBusiness _gameBusiness;
        private readonly IMapper _mapper;

        public GameController(IGameBusiness gameBusiness, IMapper mapper)
        {
            _gameBusiness = gameBusiness;
            _mapper = mapper;
        }

        public IActionResult Details(int id)
        {
            var game = _gameBusiness.GetGame(id);
            var gameDetails = _mapper.Map<GameDetailsViewModel>(game);

            return View(gameDetails);
        }
    }
}