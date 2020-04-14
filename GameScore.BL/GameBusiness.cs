using GameScore.BL.Interfaces;
using GameScore.DAL;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameScore.BL
{
    public class GameBusiness : IGameBusiness
    {
        private readonly GameScoreDbContext _context;

        public GameBusiness()
        {
            _context = new GameScoreDbContextFactory().CreateDbContext();
        }

        public Game GetGame(int id)
        {
            var game = _context.Games
                            .Where(x => x.Id == id)
                            .FirstOrDefault();

            return game;
        }
    }
}
