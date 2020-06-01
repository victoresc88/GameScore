
using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
    public interface ICacheBusiness
    {
        public Dictionary<int, Game> GetGamesByIndex(string entry);
        public void SetSearchedGames(string keyword);
        public void SetListOfGames(IEnumerable<Game> listOfGames);
    }
}
