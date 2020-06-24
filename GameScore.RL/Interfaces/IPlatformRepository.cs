using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.RL.Interfaces
{
    public interface IPlatformRepository
    {
        public IEnumerable<Platform> GetPlatforms();
    }
}
