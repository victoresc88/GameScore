using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL.Interfaces
{
    public interface IGameBusiness
    {
        public Game GetGame(int id);
    }
}
