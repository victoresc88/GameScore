using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL.Interfaces
{
    public interface IHomeBusiness
    {
        public IEnumerable<Game> GetAllGames();
    }
}
