using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.RL
{
    public class PlatformRepository : BaseRepository<Platform>, IPlatformRepository
    {
        public PlatformRepository(GameScoreDbContext context) : base(context)
        {
        }

        public IEnumerable<Platform> GetListOfPlatforms()
        {
            return _context.Platforms;
        }
    }
}
