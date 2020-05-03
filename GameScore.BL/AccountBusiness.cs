using GameScore.BL.Interfaces;
using GameScore.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL
{
    public class AccountBusiness : IAccountBusiness
    {
        private readonly GameScoreDbContext _context;

        public AccountBusiness()
        {
            _context = new GameScoreDbContextFactory().CreateDbContext();
        }

        
    }
}
