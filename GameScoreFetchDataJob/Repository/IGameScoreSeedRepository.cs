using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Repository
{
    public interface IGameScoreSeedRepository
    {
        public void SeedDB(IEnumerable<Game> gameList);
    }
}
