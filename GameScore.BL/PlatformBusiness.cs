using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.BL
{
    public class PlatformBusiness : IPlatformBusiness
    {
        private readonly IWrapperRepository _wrapperRepository;

        public PlatformBusiness(IWrapperRepository wrapperRepository)
        {
            _wrapperRepository = wrapperRepository;                
        }

        public IEnumerable<Platform> GetListOfPlatforms()
        {
            return _wrapperRepository.Platform.GetListOfPlatforms();
        }
    }
}
