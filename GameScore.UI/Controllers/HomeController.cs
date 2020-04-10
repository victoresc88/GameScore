using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GameScore.UI.Models;
using GameScore.BL;
using AutoMapper;
using GameScore.UI.ViewModels;

namespace GameScore.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly HomeBusiness _homeBusiness;
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _homeBusiness = new HomeBusiness();
        }

        public IActionResult Index()
        {
            var gameList = _mapper.Map<IEnumerable<GameViewModel>>(_homeBusiness.GetAllGames().Take(20));

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
