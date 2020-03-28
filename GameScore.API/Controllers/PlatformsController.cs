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
    public class PlatformsController : ControllerBase
    {
        private readonly GameScoreDbContext _context;

        public PlatformsController(GameScoreDbContext context)
        {
            _context = context;
        }
    }
}