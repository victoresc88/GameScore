using GameScore.DAL;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameScore.BL
{
    public class HomeBusiness
    {
        private readonly GameScoreDbContext _context;

        public HomeBusiness()
        {
            _context = new GameScoreDbContextFactory().CreateDbContext();
        }

        public List<Game> GetAllGames()
        {
            return _context.Games.ToList();
        }
    }
}
