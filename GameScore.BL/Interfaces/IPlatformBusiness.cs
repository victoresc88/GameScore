using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
    public interface IPlatformBusiness
    {
        public IEnumerable<Platform> GetPlatforms();

    }
}
