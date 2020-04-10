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

namespace GameScore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeBusiness _homeBusiness;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper, IHomeBusiness homeBusiness)
        {
            _mapper = mapper;
            _homeBusiness = homeBusiness;
        }

        public IActionResult Index()
        {
            var gameList = _mapper.Map<IEnumerable<GameViewModel>>(_homeBusiness.GetAllGames().Take(30));

            return View(gameList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
