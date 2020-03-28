using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameScore.EntityFramework.BL;
using GameScore.EntityFramework.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameScore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly GameScoreDbContext _context;

        public GamesController(GameScoreDbContext context)
        {
            _context = context;
        }
    }
}