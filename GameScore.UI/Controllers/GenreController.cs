using AutoMapper;
using GameScore.BL.Interfaces;
using GameScore.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GameScore.UI.Controllers
{
    public class GenreController : Controller
    {
        private readonly IWrapperBusiness _wrapperBusiness;
        private readonly IMapper _mapper;

        public GenreController(IWrapperBusiness wrapperBusiness, IMapper mapper)
        {
            _wrapperBusiness = wrapperBusiness;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult Search(int id)
        {
            var listOfGames = _wrapperBusiness.Game.GetGamesByGenreId(id);
            var listOfGamesViewModel = _mapper.Map<IEnumerable<GameViewModel>>(listOfGames);

            return View("_SearchList", listOfGamesViewModel);
        }
    }
}
