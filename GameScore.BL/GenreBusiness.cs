using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.BL
{
    public class GenreBusiness : IGenreBusiness
    {
        private readonly IWrapperRepository _wrapperRepository;

        public GenreBusiness(IWrapperRepository wrapperRepository)
        {
            _wrapperRepository = wrapperRepository;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _wrapperRepository.Genre.GetGenres();
        }
    }
}
